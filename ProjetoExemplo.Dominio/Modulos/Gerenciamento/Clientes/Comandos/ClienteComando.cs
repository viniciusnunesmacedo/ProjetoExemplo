using ProjetoExemplo.Dominio.Core.Comandos;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos
{
    public class ClienteComando : Comando
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
    }
}