using ProjetoExemplo.Dominio.Core.Modelos;
using System;

namespace ProjetoExemplo.Dominio.Modelos
{
    public class Produto : Entidade
    {
        public Produto(Guid id,
                       string descricao,
                       UnidadeMedida unidadeMedida)
        {
            Id = id;
            Descricao = descricao;
            UnidadeMedida = unidadeMedida;
        }

        public string Descricao { get; }
        public UnidadeMedida UnidadeMedida { get; }
    }
}
