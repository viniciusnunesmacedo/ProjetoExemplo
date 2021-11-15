using FluentValidation;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes
{
    public abstract class ClienteValidacao<T> : AbstractValidator<T> where T : ClienteComando
    {
        protected void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o nome")
                .Length(2, 150).WithMessage("O nome tem que estar entre 2 e 150 caracteres");
        }

        protected void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();            
        }

        protected void ValidarId()
        {
            RuleFor(m => m.Id)
                .NotEqual(Guid.Empty);
        }

        //protected void ValidarDataNascimento()
        //{
        //    RuleFor(m => m.DataNascimento)
        //        .NotEmpty()
        //        .Must(TerMinimoIdade)
        //        .WithMessage("O cliente tem que ter 18 anos ou mais.");
        //}

        //protected static bool TerMinimoIdade(DateTime dataNascimento)
        //{
        //    return dataNascimento <= DateTime.Now.AddYears(-18);
        //}
    }
}
