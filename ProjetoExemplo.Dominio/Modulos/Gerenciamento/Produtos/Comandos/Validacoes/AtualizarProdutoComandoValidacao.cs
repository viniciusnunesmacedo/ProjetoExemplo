namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos.Validacoes
{
    public class AtualizarProdutoComandoValidacao : ProdutoValidacao<AtualizarProdutoComando>
    {
        public AtualizarProdutoComandoValidacao()
        {
            ValidarId();
            ValidarDescricao();
            ValidarUnidadeMedida();
        }
    }
}
