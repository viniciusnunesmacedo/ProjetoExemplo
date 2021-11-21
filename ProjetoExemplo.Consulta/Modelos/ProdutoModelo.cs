using ProjetoExemplo.Dominio.Modelos;
using System;

namespace ProjetoExemplo.Consulta.Modelos
{
    public class ProdutoModelo
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
