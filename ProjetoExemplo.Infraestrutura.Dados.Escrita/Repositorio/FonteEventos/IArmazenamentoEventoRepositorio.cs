using ProjetoExemplo.Dominio.Core.Eventos;
using System;

namespace ProjetoExemplo.Infraestrutura.Dados.Escrita.Repositorio.FonteEventos
{
    public interface IArmazenamentoEventoRepositorio : IDisposable
    {
        void Armazenar(EventoArmazenado oEvento);
    }
}
