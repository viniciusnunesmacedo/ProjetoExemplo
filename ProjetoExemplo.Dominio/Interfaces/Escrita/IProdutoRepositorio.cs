using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Interfaces.Escrita
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<Produto> ObterPorId(Guid id);
        Task<Produto> ObterPorDescricao(string descricao);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Excluir(Produto produto);
    }
}
