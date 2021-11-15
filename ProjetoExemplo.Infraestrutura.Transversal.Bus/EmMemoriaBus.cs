using FluentValidation.Results;
using MediatR;
using ProjetoExemplo.Dominio.Core.Bus;
using ProjetoExemplo.Dominio.Core.Comandos;
using ProjetoExemplo.Dominio.Core.Eventos;
using System;
using System.Threading.Tasks;

namespace ProjetoExemplo.Infraestrutura.Tranversal.Bus
{

    public sealed class EmMemoriaBus : IMediadorManipulacao
    {
        private readonly IMediator _mediador;
        private readonly IArmazenamentoEvento _armazenamentoEvento;

        public EmMemoriaBus(IArmazenamentoEvento armazenamentoEvento, IMediator mediador)
        {
            _armazenamentoEvento = armazenamentoEvento;
            _mediador = mediador;
        }

        public async Task GerarEvento<T>(T evento) where T : Evento
        {
            if (!evento.TipoMensagem.Equals("DomainNotification"))
                _armazenamentoEvento?.Salvar(evento);

            await _mediador.Publish(evento);
        }

        public async Task<ValidationResult> EnviarComando<T>(T comando) where T : Comando
        {
            return await _mediador.Send(comando);
        }
    }
}
