using ProjetoExemplo.Dominio.Core.Eventos;
using ProjetoExemplo.Dominio.Modelos;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Eventos
{
    public class ProdutoAtualizadoEvento : Evento
    {
        public ProdutoAtualizadoEvento(Guid id,
                                       string descricao,
                                       UnidadeMedida unidadeMedida)
        {
            Id = id;
            AgregadoId = id;
            Descricao = descricao;
            UnidadeMedida = unidadeMedida;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; }
        public UnidadeMedida UnidadeMedida { get; }
    }
}
