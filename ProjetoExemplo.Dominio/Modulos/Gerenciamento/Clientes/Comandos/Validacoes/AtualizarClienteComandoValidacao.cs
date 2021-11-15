namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes
{
    public class AtualizarClienteComandoValidacao : ClienteValidacao<AtualizarClienteComando>
    {
        public AtualizarClienteComandoValidacao()
        {
            ValidarId();
            ValidarNome();
            ValidarEmail();
        }
    }
}
