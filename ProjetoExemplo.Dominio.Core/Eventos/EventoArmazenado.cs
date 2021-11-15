using System;

namespace ProjetoExemplo.Dominio.Core.Eventos
{
    public class EventoArmazenado : Evento
    {
        public EventoArmazenado(Evento oEvento, string dados, string usuario)
        {
            Id = Guid.NewGuid();
            AgregadoId = oEvento.AgregadoId;
            TipoMensagem = oEvento.TipoMensagem;
            Dados = dados;
            Usuario = usuario;
        }

        // EF Constructor
        protected EventoArmazenado() { }

        public Guid Id { get; private set; }

        public string Dados { get; private set; }

        public string Usuario { get; private set; }
    }
}
