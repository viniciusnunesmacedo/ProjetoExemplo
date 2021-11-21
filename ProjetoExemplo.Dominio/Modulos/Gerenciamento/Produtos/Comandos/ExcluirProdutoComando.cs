using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos.Validacoes;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos
{
    public class ExcluirProdutoComando : ProdutoComando
    {
        public ExcluirProdutoComando(Guid id)
        {
            Id = id;
            AgregadoId = id;
        }

        public override bool EValido()
        {
            ResultadoValidacao = new ExcluirProdutoComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
