using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Interfaces.Leitura
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<Cliente> ObterPorId(Guid id);
        Task<Cliente> ObterPorEmail(string email);
        Task<IEnumerable<Cliente>> ObterTodos();
    }
}
