using System;

namespace ProjetoExemplo.Dominio.Core.Eventos
{
    public abstract class Mensagem
    {
        protected Mensagem()
        {
            TipoMensagem = GetType().Name;
        }

        public string TipoMensagem { get; protected set; }
        public Guid AgregadoId { get; protected set; }
    }
}
