using ProjetoExemplo.Dominio.Core.Modelos;
using ProjetoExemplo.Dominio.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoExemplo.Dominio.Modelos
{
    public class Pedido : Entidade, IAgregadoRaiz
    {
        private IList<ItemPedido> _itensPedido;

        public Pedido(Guid clienteId, Guid enderecoId, long numeroPedido)
        {
            ClienteId = clienteId;
            EnderecoId = enderecoId;
            NumeroPedido = numeroPedido;

            _itensPedido = new List<ItemPedido>();
            ItensPedido = new List<ItemPedido>();
        }

        public Guid ClienteId { get; }
        public Guid EnderecoId { get; }
        public long NumeroPedido { get; }
        public long DataCriacao { get; }

        public IEnumerable<ItemPedido> ItensPedido 
        {
            get => _itensPedido.ToList();
            set => _itensPedido = value.ToList();
        }

        public void AdicionarItem(ItemPedido itemPedido)
        {
            // Validar se tem pedido Id
            // Validar os campos

            _itensPedido.Add(itemPedido);
        }

        public void ExcluirItem(ItemPedido itemPedido)
        {
            _itensPedido.Remove(itemPedido);
        }
    }
}
