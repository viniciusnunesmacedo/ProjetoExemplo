using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProjetoExemplo.Dominio.Modelos;

namespace ProjetoExemplo.Consulta.NormalizadoresFontesEventos
{
    public class DadosHistoricoProduto
    {
        public string Acao { get; set; }
        public string Id { get; set; }
        public string Descricao { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UnidadeMedida? UnidadeMedida { get; set; }
        public string DataHora { get; set; }
        public string Quem { get; set; }
    }
}
