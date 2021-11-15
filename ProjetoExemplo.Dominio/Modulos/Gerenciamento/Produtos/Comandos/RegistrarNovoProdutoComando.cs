using ProjetoExemplo.Dominio.Modelos;
using ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos.Validacoes;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos
{
    public class RegistrarNovoProdutoComando : ProdutoComando
    {
        public RegistrarNovoProdutoComando(Guid id,
                                           string descricao,
                                           UnidadeMedida unidadeMedida)
        {
            Id = id;
            Descricao = descricao;
            UnidadeMedida = unidadeMedida;
        }

        public override bool EValido()
        {
            ResultadoValidacao = new RegistrarNovoProdutoComandoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
