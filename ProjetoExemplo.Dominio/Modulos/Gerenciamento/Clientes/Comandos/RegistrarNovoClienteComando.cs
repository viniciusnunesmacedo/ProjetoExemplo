using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos
{
    public class RegistrarNovoClienteComando : ClienteComando
    {
        public RegistrarNovoClienteComando(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public override bool EValido()
        {
            ResultadoValidacao = new RegistrarNovoClienteComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
