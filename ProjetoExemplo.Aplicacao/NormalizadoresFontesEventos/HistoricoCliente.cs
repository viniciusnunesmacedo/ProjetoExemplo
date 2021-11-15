using ProjetoExemplo.Dominio.Core.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ProjetoExemplo.Aplicacao.NormalizadoresFontesEventos
{
    public static class HistoricoCliente
    {
        public static IList<DadosHistoricoCliente> DadosHistorico { get; set; }

        public static IList<DadosHistoricoCliente> ParaJavaScriptHistoricoCliente(IList<EventoArmazenado> eventosArmazenados)
        {
            DadosHistorico = new List<DadosHistoricoCliente>();
            HistoricoClienteDeserializer(eventosArmazenados);

            var sorted = DadosHistorico.OrderBy(c => c.DataHora);
            var list = new List<DadosHistoricoCliente>();
            var last = new DadosHistoricoCliente();

            foreach (var change in sorted)
            {
                var jsSlot = new DadosHistoricoCliente
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    Acao = string.IsNullOrWhiteSpace(change.Acao) ? "" : change.Acao,
                    DataHora = change.DataHora,
                    Quem = change.Quem
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void HistoricoClienteDeserializer(IEnumerable<EventoArmazenado> eventosArmazenados)
        {
            foreach (var e in eventosArmazenados)
            {
                var dadosHistorico = JsonSerializer.Deserialize<DadosHistoricoCliente>(e.Dados);
                dadosHistorico.DataHora = DateTime.Parse(dadosHistorico.DataHora).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.TipoMensagem)
                {
                    case "ClienteRegistradoEvento":
                        dadosHistorico.Acao = "Registrado";
                        dadosHistorico.Quem = e.Usuario;
                        break;
                    case "ClienteAtualizadoEvento":
                        dadosHistorico.Acao = "Atualizado";
                        dadosHistorico.Quem = e.Usuario;
                        break;
                    case "ClienteExcluidoEvento":
                        dadosHistorico.Acao = "Excluido";
                        dadosHistorico.Quem = e.Usuario;
                        break;
                    default:
                        dadosHistorico.Acao = "Não reconhecido";
                        dadosHistorico.Quem = e.Usuario ?? "Anonymous";
                        break;

                }
                DadosHistorico.Add(dadosHistorico);
            }
        }
    }
}
