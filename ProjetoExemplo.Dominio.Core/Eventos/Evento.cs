using MediatR;
using System;

namespace ProjetoExemplo.Dominio.Core.Eventos
{
    public abstract class Evento : Mensagem, INotification
    {
        protected Evento()
        {
            DataHora = DateTime.Now;
        }

        public DateTime DataHora { get; set; }
    }
}
