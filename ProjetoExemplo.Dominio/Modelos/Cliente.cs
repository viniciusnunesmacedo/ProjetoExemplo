using ProjetoExemplo.Dominio.Core.Modelos;
using ProjetoExemplo.Dominio.Interfaces.Base;
using System;

namespace ProjetoExemplo.Dominio.Modelos
{
    public class Cliente : Entidade, IAgregadoRaiz
    {
        public Cliente(Guid id,
                       string nome, 
                       string email)
        {

            Nome = nome;
            Email = email;
            Id = id;
        }

        public string Nome { get; }
        public string Email { get; }
    }
}
