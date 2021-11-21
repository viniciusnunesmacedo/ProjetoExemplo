using ProjetoExemplo.Dominio.Core.Eventos;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Eventos
{
    public class ClienteExcluidoEvento : Evento
    {
        public ClienteExcluidoEvento(Guid id)
        {
            Id = id;
            AgregadoId = id;
        }

        public Guid Id { get; private set; }
    }
}
