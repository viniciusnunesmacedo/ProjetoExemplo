using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoExemplo.Dominio.Core.Eventos;

namespace ProjetoExemplo.Infraestrutura.Dados.Escrita.Mapeamentos
{
    public class EventoArmazenadoMap : IEntityTypeConfiguration<EventoArmazenado>
    {
        public void Configure(EntityTypeBuilder<EventoArmazenado> builder)
        {
            builder.Property(c => c.DataHora)
                .HasColumnName("DataCriacao");

            builder.Property(c => c.TipoMensagem)
                .HasColumnName("Acao")
                .HasColumnType("varchar(100)");
        }
    }
}
