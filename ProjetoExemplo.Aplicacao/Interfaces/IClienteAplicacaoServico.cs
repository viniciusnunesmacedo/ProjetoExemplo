using FluentValidation.Results;
using ProjetoExemplo.Aplicacao.ModelosEscrita;
using ProjetoExemplo.Aplicacao.ModelosLeitura;
using ProjetoExemplo.Aplicacao.NormalizadoresFontesEventos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Interfaces
{
    public interface IClienteAplicacaoServico : IDisposable
    {
        Task<IEnumerable<ClienteModeloLeitura>> ObterTodos();
        Task<ClienteModeloLeitura> ObterPorId(Guid id);

        Task<ValidationResult> Registrar(ClienteModeloEscrita clienteModeloEscrita);
        Task<ValidationResult> Atualizar(ClienteModeloEscrita clienteModeloEscrita);
        Task<ValidationResult> Excluir(Guid id);

        Task<IList<DadosHistoricoCliente>> ObterTodoHistorico(Guid id);
    }
}
