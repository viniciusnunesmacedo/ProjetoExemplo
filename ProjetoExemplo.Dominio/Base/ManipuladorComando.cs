using FluentValidation.Results;
using ProjetoExemplo.Dominio.Interfaces.Base;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Base
{
    /// <summary>
    /// CommandHandler
    /// </summary>
    public abstract class ManipuladorComando
    {
        protected ValidationResult ResultadoValidacao;

        protected ManipuladorComando()
        {
            ResultadoValidacao = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ResultadoValidacao.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Persistir(IUnidadeTrabalho ut, string mensagem)
        {
            if (!await ut.Persistir()) AdicionarErro(mensagem);

            return ResultadoValidacao;
        }

        protected async Task<ValidationResult> Persistir(IUnidadeTrabalho ut)
        {
            return await Persistir(ut, "Ocorreu um erro ao salvar os dados").ConfigureAwait(false);
        }
    }
}
