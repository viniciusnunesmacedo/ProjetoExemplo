using ProjetoExemplo.Dominio.Interfaces.Base;
using ProjetoExemplo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Interfaces.Leitura
{
    public interface IProdutoRepositorio : IRepositorio<Produto>
    {
        Task<Produto> ObterPorId(Guid id);
        Task<Produto> ObterPorDescricao(string descricao);
        Task<IEnumerable<Produto>> ObterTodos();
    }
}
