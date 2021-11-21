using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Dominio.Core.Modelos;
using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Infraestrutura.Dados.Escrita.Mapeamentos;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoExemplo.Infraestrutura.Dados.Escrita.Contextos
{
    public sealed class ProjetoExemploContexto : DbContext, IUnidadeTrabalho
    {
        private readonly IMediadorManipulacao _mediadorManipulacao;

        public ProjetoExemploContexto(DbContextOptions<ProjetoExemploContexto> opcoes, IMediadorManipulacao mediarManipulacao) : base(opcoes)
        {
            _mediadorManipulacao = mediarManipulacao;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Evento>();

            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //    e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            //    property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());


            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Persistir()
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediadorManipulacao.PublishDomainEvents(this).ConfigureAwait(false);

            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed through the DbContext will be committed
            var success = await SaveChangesAsync() > 0;

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediadorManipulacao mediador, T ctx) where T : DbContext
        {
            var entidadesDominio = ctx.ChangeTracker
                .Entries<Entidade>()
                .Where(x => x.Entity.EventosDominio != null && x.Entity.EventosDominio.Any());

            var eventosDominio = entidadesDominio
                .SelectMany(x => x.Entity.EventosDominio)
                .ToList();

            entidadesDominio.ToList()
                .ForEach(entity => entity.Entity.LimparEventoDominio());

            var tasks = eventosDominio
                .Select(async (eventoDominio) => {
                    await mediador.GerarEvento(eventoDominio);
                });

            await Task.WhenAll(tasks);
        }
    }
}
