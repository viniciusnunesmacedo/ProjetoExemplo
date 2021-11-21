using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Infraestrutura.Dados.Escrita.Mapeamentos;

namespace ProjetoExemplo.Infraestrutura.Dados.Escrita.Contextos
{
    public class ArmazenamentoEventoSqlContexto : DbContext
    {
        public ArmazenamentoEventoSqlContexto(DbContextOptions<ArmazenamentoEventoSqlContexto> opcoes) : base(opcoes) { }

        public DbSet<EventoArmazenado> EventosArmazenado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventoArmazenadoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
