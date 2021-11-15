using FluentValidation.Results;
using MediatR;
using ProjetoExemplo.Dominio.Core.Eventos;
using System;

namespace ProjetoExemplo.Dominio.Core.Comandos
{
    public abstract class Comando : Mensagem, IRequest<ValidationResult>, IBaseRequest
    {
        protected Comando() { }

        public DateTime Timestamp { get; }

        /// <summary>
        /// Resultado da Validação
        /// </summary>
        public ValidationResult ResultadoValidacao { get; set; }

        public virtual bool EValido() { return true; }
    }
}
