using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos
{
    public class AtualizarClienteComando : ClienteComando
    {
        public AtualizarClienteComando(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public override bool EValido()
        {
            ResultadoValidacao = new AtualizarClienteComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
