using MediatR;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Eventos;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.ManipuladoresEventos
{
    public class ClienteManipuladorEventos : 
        INotificationHandler<ClienteRegistradoEvento>,
        INotificationHandler<ClienteAtualizadoEvento>,
        INotificationHandler<ClienteExcluidoEvento>
    {
        public Task Handle(ClienteRegistradoEvento notificacao, CancellationToken tokenCancelamento)
        {
            // Enviar algum e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ClienteAtualizadoEvento notificacao, CancellationToken tokenCancelamento)
        {
            // Enviar algum e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ClienteExcluidoEvento notificacao, CancellationToken tokenCancelamento)
        {
            // Enviar algum e-mail

            return Task.CompletedTask;
        }
    }
}
