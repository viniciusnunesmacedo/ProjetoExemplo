using MediatR;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Eventos;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.ManipuladoresEventos
{
    public class ProdutoManipuladorEventos :
        INotificationHandler<ProdutoRegistradoEvento>,
        INotificationHandler<ProdutoAtualizadoEvento>,
        INotificationHandler<ProdutoExcluidoEvento>
    {
        public Task Handle(ProdutoRegistradoEvento notificacao, CancellationToken tokenCancelamento)
        {
            // Enviar algum e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProdutoExcluidoEvento notificacao, CancellationToken tokenCancelamento)
        {
            // Enviar algum e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProdutoAtualizadoEvento notificacao, CancellationToken tokenCancelamento)
        {
            // Enviar algum e-mail

            return Task.CompletedTask;
        }
    }
}