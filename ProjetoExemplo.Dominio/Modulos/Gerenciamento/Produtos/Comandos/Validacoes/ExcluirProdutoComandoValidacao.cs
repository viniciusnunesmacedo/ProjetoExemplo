namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos.Validacoes
{
    public class ExcluirProdutoComandoValidacao : ProdutoValidacao<ExcluirProdutoComando>
    {
        public ExcluirProdutoComandoValidacao()
        {
            ValidarId();
        }
    }
}
