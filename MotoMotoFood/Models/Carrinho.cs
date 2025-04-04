using System;
using System.Collections.Generic;
using System.Linq;
using MotoMotoFood.Services;

namespace MotoMotoFood.Models
{
    public class Carrinho
    {
        public Dictionary<Produto, int> Produtos { get; private set; }

        public Carrinho()
        {
            Produtos = new Dictionary<Produto, int>();
        }

        public bool AdicionarProduto(Produto produto)
        {
            if (Produtos.Any())
            {
                string chaveRestauranteCarrinho = Produtos.Keys.First().ChaveRestauranteOrigem;
                string produtoNome = Produtos.Keys.First().Nome;
                if (produto.ChaveRestauranteOrigem != chaveRestauranteCarrinho)
                {
                    Console.WriteLine("Você só pode adicionar produtos do mesmo restaurante ao carrinho!");
                    Console.WriteLine("Seu carrinho já contém produtos de outro restaurante.");
                    return false;
                }
                if (produtoNome == produto.Nome)
                {
                    Console.WriteLine("Ja existe este produto no carrinho");
                    return false;
                }
            }
           
            Produtos[produto] = produto.Quantidade;
            //Console.WriteLine($"Quantidade do produto {produto.Nome} atualizada no carrinho!");
            return true;
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
                var i = 1;
            foreach (var item in Produtos)
            {
                Console.WriteLine($"{i}| Produto: {item.Key.Nome} | Quantidade: {item.Value} | Subtotal: {item.Key.Preco * item.Value:C}");
                i++;
            }
            Console.WriteLine($"Total: {CalcularTotal():C}\n");
        }
    }
}
