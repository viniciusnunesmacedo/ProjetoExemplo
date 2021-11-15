namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes
{
    public class ExcluirClienteComandoValidacao : ClienteValidacao<ExcluirClienteComando>
    {
        public ExcluirClienteComandoValidacao()
        {
            ValidarId();
        }
    }
}
