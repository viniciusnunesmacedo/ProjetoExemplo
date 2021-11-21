using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Infraestrutura.Dados.Leitura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoExemplo.Infraestrutura.Dados.Leitura.Repositorio.FonteEventos
{
    public class ArmazenamentoEventoRepositorio : IArmazenamentoEventoRepositorio
    {
        private readonly ArmazenamentoEventoSqlContexto _contexto;

        public ArmazenamentoEventoRepositorio(ArmazenamentoEventoSqlContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IList<EventoArmazenado>> Todos(Guid agregadorId)
        {
            return await (from e in _contexto.EventosArmazenado where e.AgregadoId == agregadorId select e).ToListAsync();
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
