using System;
using System.Collections.Generic;
using System.Linq;

namespace MotoMotoFood.Models
{
    public class Carrinho
    {
        public Dictionary<Produto, int> Produtos { get; private set; }

        public Carrinho()
        {
            Produtos = new Dictionary<Produto, int>();
        }

        public void AdicionarProduto(Produto produto, int quantidade = 1)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade deve ser maior que zero.");

            if (Produtos.ContainsKey(produto))
                Produtos[produto] += quantidade;
            else
                Produtos[produto] = quantidade;
        }

        public void RemoverProduto(Produto produto, int quantidade = 1)
        {
            if (!Produtos.ContainsKey(produto))
                return;

            if (quantidade >= Produtos[produto])
                Produtos.Remove(produto);
            else
                Produtos[produto] -= quantidade;
        }

        public decimal CalcularTotal()
        {
            return Produtos.Sum(p => p.Key.Preco * p.Value);
        }

        public void ExibirCarrinho()
        {
            Console.WriteLine("=== Carrinho de Compras: ===");
            foreach (var item in Produtos)
            {
                Console.WriteLine($"Produto: {item.Key.Nome} | Quantidade: {item.Value} | Subtotal: {item.Key.Preco * item.Value:C}");
            }
            Console.WriteLine($"Total: {CalcularTotal():C}\n");
        }
    }
}
