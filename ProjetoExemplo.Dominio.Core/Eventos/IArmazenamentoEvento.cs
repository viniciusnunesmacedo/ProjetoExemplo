namespace ProjetoExemplo.Dominio.Core.Eventos
{
    public interface IArmazenamentoEvento
    {
        void Salvar<T>(T oEvento) where T : Evento;
    }
}
