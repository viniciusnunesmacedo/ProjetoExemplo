using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Core.Notificacoes
{
    public class ManipuladorNotificacaoDominio : INotificationHandler<NotificacaoDominio>
    {
        private List<NotificacaoDominio> _notificacoes;

        public ManipuladorNotificacaoDominio()
        {
            _notificacoes = new List<NotificacaoDominio>();
        }

        public Task Handle(NotificacaoDominio mensagem, CancellationToken tokenCancelamento)
        {
            _notificacoes.Add(mensagem);

            return Task.CompletedTask;
        }

        public virtual List<NotificacaoDominio> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public virtual bool TemNotificacoes()
        {
            return ObterNotificacoes().Any();
        }

        public void Dispose()
        {
            _notificacoes = new List<NotificacaoDominio>();
        }
    }
}
