using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoExemplo.Servicos.Api.Leitura.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _erros = new List<string>();

        protected ActionResult RespostaCustomizada(object result = null)
        {
            if (OperacaoEValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", _erros.ToArray() }
            }));
        }

        protected ActionResult RespostaCustomizada(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AdicionarErro(error.ErrorMessage);
            }

            return RespostaCustomizada();
        }

        protected ActionResult RespostaCustomizada(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AdicionarErro(error.ErrorMessage);
            }

            return RespostaCustomizada();
        }

        protected bool OperacaoEValida()
        {
            return !_erros.Any();
        }

        protected void AdicionarErro(string erro)
        {
            _erros.Add(erro);
        }

        protected void LimparErros()
        {
            _erros.Clear();
        }
    }
}
