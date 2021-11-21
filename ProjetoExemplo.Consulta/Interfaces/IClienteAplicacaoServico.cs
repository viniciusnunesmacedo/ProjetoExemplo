using ProjetoExemplo.Consulta.Modelos;
using ProjetoExemplo.Consulta.NormalizadoresFontesEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Consulta.Interfaces
{
    public interface IClienteAplicacaoServico
    {
        Task<IEnumerable<ClienteModelo>> ObterTodos();
        Task<ClienteModelo> ObterPorId(Guid id);
        Task<IList<DadosHistoricoCliente>> ObterTodoHistorico(Guid id);
    }
}
