using ProjetoExemplo.Dominio.Core.Eventos;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Eventos
{
    public class ProdutoExcluidoEvento : Evento
    {
        public ProdutoExcluidoEvento(Guid id)
        {
            Id = id;
            AgregadoId = id;
        }

        public Guid Id { get; private set; }
    }
}
