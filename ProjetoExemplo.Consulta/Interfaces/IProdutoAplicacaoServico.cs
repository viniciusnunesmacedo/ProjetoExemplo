using ProjetoExemplo.Consulta.Modelos;
using ProjetoExemplo.Consulta.NormalizadoresFontesEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Consulta.Interfaces
{
    public interface IProdutoAplicacaoServico
    {
        Task<IEnumerable<ProdutoModelo>> ObterTodos();
        Task<ProdutoModelo> ObterPorId(Guid id);
        Task<IList<DadosHistoricoProduto>> ObterTodoHistorico(Guid id);
    }
}
