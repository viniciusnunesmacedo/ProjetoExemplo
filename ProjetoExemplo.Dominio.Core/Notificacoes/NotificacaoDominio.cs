using ProjetoExemplo.Dominio.Core.Eventos;
using System;

namespace ProjetoExemplo.Dominio.Core.Notificacoes
{
    public class NotificacaoDominio : Evento
    {
        public Guid NotificacaoDominioId { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public NotificacaoDominio(string chave, string valor)
        {
            NotificacaoDominioId = Guid.NewGuid();
            Versao = 1;
            Chave = chave;
            Valor = valor;
        }
    }
}
