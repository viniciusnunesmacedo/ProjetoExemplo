using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Interfaces.Escrita
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        Task<Cliente> ObterPorId(Guid id);
        Task<Cliente> ObterPorEmail(string email);

        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(Cliente cliente);
    }
}
