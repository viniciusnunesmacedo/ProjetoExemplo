using ProjetoExemplo.Dominio.Core.Comandos;
using ProjetoExemplo.Dominio.Modelos;
using System;

namespace ProjetoExemplo.Dominio.Modulos.Gerenciamento.Produtos.Comandos
{
    public class ProdutoComando : Comando
    {
        public Guid Id { get; protected set; }
        public string Descricao { get; protected set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
