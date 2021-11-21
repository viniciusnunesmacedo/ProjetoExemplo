using ProjetoExemplo.Dominio.Core.Modelos;
using ProjetoExemplo.Dominio.Interfaces.Base;
using System;

namespace ProjetoExemplo.Dominio.Modelos
{
    public class Produto : Entidade, IAgregadoRaiz
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
