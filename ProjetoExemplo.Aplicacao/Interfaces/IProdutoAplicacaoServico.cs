using FluentValidation.Results;
using ProjetoExemplo.Aplicacao.Modelos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Aplicacao.Interfaces
{
    public interface IProdutoAplicacaoServico : IDisposable
    {
        Task<ValidationResult> Registrar(ProdutoModelo ProdutoModelo);
        Task<ValidationResult> Atualizar(ProdutoModelo ProdutoModelo);
        Task<ValidationResult> Excluir(Guid id);
    }
}
