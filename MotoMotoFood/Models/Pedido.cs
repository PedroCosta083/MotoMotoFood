using System;
using System.Collections.Generic;

namespace MotoMotoFood.Models
{
    public class Pedido
    {
        public Cliente Cliente { get; private set; }
        public Restaurante Restaurante { get; private set; }
        public Entregador? Entregador { get; private set; }
        public decimal TaxaEntrega { get; private set; }
        public decimal Total { get; private set; }
        public Dictionary<Produto, int> Produtos { get; private set; }
        public string Status { get; private set; }

        public Pedido(Cliente cliente, Restaurante restaurante, decimal distanciaEntrega)
        {
            if (!cliente.Carrinho.Produtos.Any())
                throw new InvalidOperationException("O carrinho está vazio!");

            Cliente = cliente;
            Restaurante = restaurante;
            TaxaEntrega = CalcularTaxaEntrega(distanciaEntrega);
            Produtos = new Dictionary<Produto,int>(cliente.Carrinho.Produtos);
            Total = cliente.Carrinho.CalcularTotal() + TaxaEntrega;
            Status = "Aguardando Entregador";
        }

        private decimal CalcularTaxaEntrega(decimal distancia)
        {
            if (distancia <= 5) return distancia * 2.00m;
            if (distancia <= 10) return distancia * 1.50m;
            return distancia * 1.00m;
        }

        public void AtribuirEntregador(Entregador entregador)
        {
            if (entregador == null)
                throw new ArgumentException("Entregador inválido!");

            Entregador = entregador;
            Status = "Em Andamento";
        }

        public bool FinalizarPedido()
        {
            if (Entregador == null)
                throw new InvalidOperationException("Pedido sem entregador!");

            if (Cliente.Conta.DeduzirSaldo(Total))
            {
                Restaurante.Conta.Depositar(Total - TaxaEntrega);
                Entregador.Conta.Depositar(TaxaEntrega);
                Status = "Entregue";
                return true;
            }
            return false;
        }
    }
}
