namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos.Validacoes
{
    public class RegistrarNovoProdutoComandoValidacao : ProdutoValidacao<RegistrarNovoProdutoComando>
    {
        public RegistrarNovoProdutoComandoValidacao()
        {
            ValidarDescricao();
            ValidarUnidadeMedida();
        }
    }
}
