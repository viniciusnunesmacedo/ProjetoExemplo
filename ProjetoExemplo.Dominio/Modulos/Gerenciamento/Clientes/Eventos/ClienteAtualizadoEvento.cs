using ProjetoExemplo.Dominio.Core.Eventos;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Eventos
{
    public class ClienteAtualizadoEvento : Evento
    {
        public ClienteAtualizadoEvento(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            AgregadoId = id;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
