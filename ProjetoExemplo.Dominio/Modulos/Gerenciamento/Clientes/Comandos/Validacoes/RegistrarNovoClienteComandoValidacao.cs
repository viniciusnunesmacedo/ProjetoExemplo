namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Clientes.Comandos.Validacoes
{
    public class RegistrarNovoClienteComandoValidacao : ClienteValidacao<RegistrarNovoClienteComando>
    {
        public RegistrarNovoClienteComandoValidacao()
        {
            ValidarNome();
            ValidarEmail();
        }
    }
}