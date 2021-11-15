using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Interfaces
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<Cliente> ObterPorId(Guid id);
        Task<Cliente> ObterPorEmail(string email);
        Task<IEnumerable<Cliente>> ObterTodos();

        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(Cliente cliente);
    }
}
