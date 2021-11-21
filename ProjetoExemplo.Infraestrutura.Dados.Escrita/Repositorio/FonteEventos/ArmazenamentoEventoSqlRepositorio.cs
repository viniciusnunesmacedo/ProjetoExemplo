using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Infraestrutura.Dados.Escrita.Contextos;

namespace ProjetoExemplo.Infraestrutura.Dados.Escrita.Repositorio.FonteEventos
{
    public class ArmazenamentoEventoRepositorio : IArmazenamentoEventoRepositorio
    {
        private readonly ArmazenamentoEventoSqlContexto _contexto;

        public ArmazenamentoEventoRepositorio(ArmazenamentoEventoSqlContexto contexto)
        {
            _contexto = contexto;
        }

        public void Armazenar(EventoArmazenado oEvento)
        {
            _contexto.EventosArmazenado.Add(oEvento);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
