using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos
{
    public class ExcluirClienteComando : ClienteComando
    {
        public ExcluirClienteComando(Guid id)
        {
            Id = id;
            AgregadoId = id;
        }

        public override bool EValido()
        {
            ResultadoValidacao = new ExcluirClienteComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
