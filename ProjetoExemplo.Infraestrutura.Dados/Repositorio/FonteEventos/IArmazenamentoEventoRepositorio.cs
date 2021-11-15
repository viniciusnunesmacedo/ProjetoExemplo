using ProjetoExemplo.Dominio.Core.Eventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Infraestrutura.Dados.Repositorio.FonteEventos
{
    public interface IArmazenamentoEventoRepositorio : IDisposable
    {
        void Armazenar(EventoArmazenado oEvento);
        Task<IList<EventoArmazenado>> Todos(Guid agregadoId);
    }
}
