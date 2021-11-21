using ProjetoExemplo.Dominio.Core.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace ProjetoExemplo.Consulta.NormalizadoresFontesEventos
{
    public static class HistoricoProduto
    {
        public static IList<DadosHistoricoProduto> DadosHistorico { get; set; }

        public static IList<DadosHistoricoProduto> ParaJavaScriptHistoricoProduto(IList<EventoArmazenado> eventosArmazenados)
        {
            DadosHistorico = new List<DadosHistoricoProduto>();
            HistoricoProdutoDeserializer(eventosArmazenados);

            var sorted = DadosHistorico.OrderBy(c => c.DataHora);
            var list = new List<DadosHistoricoProduto>();
            var last = new DadosHistoricoProduto();

            foreach (var change in sorted)
            {
                var jsSlot = new DadosHistoricoProduto
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Descricao = string.IsNullOrWhiteSpace(change.Descricao) || change.Descricao == last.Descricao
                        ? ""
                        : change.Descricao,
                    UnidadeMedida = change.UnidadeMedida == last.UnidadeMedida
                        ? null
                        : change.UnidadeMedida,
                    Acao = string.IsNullOrWhiteSpace(change.Acao) ? "" : change.Acao,
                    DataHora = change.DataHora,
                    Quem = change.Quem
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void HistoricoProdutoDeserializer(IEnumerable<EventoArmazenado> eventosArmazenados)
        {
            foreach (var e in eventosArmazenados)
            {
                var dadosHistorico = JsonSerializer.Deserialize<DadosHistoricoProduto>(e.Dados);
                dadosHistorico.DataHora = DateTime.Parse(dadosHistorico.DataHora).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.TipoMensagem)
                {
                    case "ProdutoRegistradoEvento":
                        dadosHistorico.Acao = "Registrado";
                        dadosHistorico.Quem = e.Usuario;
                        break;
                    case "ProdutoAtualizadoEvento":
                        dadosHistorico.Acao = "Atualizado";
                        dadosHistorico.Quem = e.Usuario;
                        break;
                    case "ProdutoExcluidoEvento":
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
