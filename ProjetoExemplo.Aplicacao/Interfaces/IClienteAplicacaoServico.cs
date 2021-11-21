using FluentValidation.Results;
using ProjetoExemplo.Aplicacao.Modelos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Interfaces
{
    public interface IClienteAplicacaoServico : IDisposable
    {
        Task<ValidationResult> Registrar(ClienteModelo clienteModelo);
        Task<ValidationResult> Atualizar(ClienteModelo clienteModelo);
        Task<ValidationResult> Excluir(Guid id);
    }
}
