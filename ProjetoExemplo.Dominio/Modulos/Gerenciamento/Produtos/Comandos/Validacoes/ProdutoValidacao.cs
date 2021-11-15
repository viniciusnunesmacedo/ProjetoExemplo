using FluentValidation;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos.Validacoes
{
    public abstract class ProdutoValidacao<T> : AbstractValidator<T> where T : ProdutoComando
    {
        protected void ValidarId()
        {
            RuleFor(m => m.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidarDescricao()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a descrição")
                .Length(2, 150).WithMessage("A descrição tem que estar entre 2 e 150 caracteres");
        }

        protected void ValidarUnidadeMedida()
        {
            RuleFor(c => c.UnidadeMedida)
                .NotEmpty().WithMessage("Informe a Unidade de Medida");
        }
    }
}
