using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoMotoFood.Models;

namespace MotoMotoFood.Services
{
    public static class CarrinhoService
    {
        public static void VisualizarCarrinho(Cliente cliente)
        {
            if (cliente == null)
            {
                Console.WriteLine(nameof(cliente), "Cliente não pode ser nulo.");
                return;
            }
            if (cliente.Carrinho.Produtos.Count == 0)
            {
                Console.WriteLine("Seu carrinho está vazio!");
                Helpers.LerOpcaoSair();
                return;
            }
            Console.Clear();
            MenuCarrinho(cliente);
        }

        private static void MenuCarrinho(Cliente cliente)
        {
            cliente.Carrinho.ExibirCarrinho();

            Console.WriteLine("=== Menu Carrinho ===");
            
            Console.WriteLine("1. Alterar quantidade do produto");
            Console.WriteLine("2. Remover produto");
            Console.WriteLine("3. Limpar Carrinho");
            Console.WriteLine("4. Finalizar Pedido");
            Console.WriteLine("0. Voltar");
            var escolha = Helpers.LerString("Selecione uma opção");

            switch (escolha)
            {
                case "1":
                    MenuAlterarProduto(cliente);
                    break;
                case "2":
                    MenuRemoverProduto();
                    break;
                case "3":
                    LimparCarrinho(cliente);
                    break;
            }
        }

        private static void MenuRemoverProduto()
        {
            var escolha = Helpers.LerString("Selecione uma opção");

        }
        private static void MenuAlterarProduto(Cliente cliente)
        {
            Console.Clear();
            cliente.Carrinho.ExibirCarrinho();

            if (cliente.Carrinho.Produtos.Count == 0)
            {
                Console.WriteLine("Não há produtos no carrinho para alterar.");
                Helpers.LerOpcaoSair();
                return;
            }

            int index = Helpers.LerInteiroComValorMaximo(
                "Selecione o número do produto que deseja alterar (0 para voltar): ",
                cliente.Carrinho.Produtos.Count);

            if (index == -1) return;

            var produto = cliente.Carrinho.Produtos.Keys.ElementAt(index);
            int quantidadeAtual = cliente.Carrinho.Produtos[produto];

            Console.WriteLine($"\nProduto selecionado: {produto.Nome}");
            Console.WriteLine($"Quantidade atual: {quantidadeAtual}");
            Console.WriteLine($"Quantidade disponível em estoque: {produto.QuantidadeEstoque}");

            int novaQuantidade = Helpers.LerInteiroComValorMaximo(
                $"Digite a nova quantidade (1-{produto.QuantidadeEstoque + quantidadeAtual}): ",
                produto.QuantidadeEstoque + quantidadeAtual);

            if (novaQuantidade <= 0)
            {
                cliente.Carrinho.RemoverProduto(produto);
                Console.WriteLine("Produto removido do carrinho!");
            }
            else
            {
                cliente.Carrinho.Produtos[produto] = novaQuantidade;
                Console.WriteLine("Quantidade atualizada com sucesso!");
            }

            Helpers.LerOpcaoSair();
        }
        public static void AdicionarProdutoAoCarrinho(Cliente cliente,List<Produto> produtosDisponiveis)
        {
            Console.WriteLine("V. Voltar");
            int index = Helpers.LerInteiroComValorMaximo("Escolha um produto para adicionar ao carrinho: ", produtosDisponiveis.Count);
            if (index == -1) { return; }
            ;
            Produto produto = new Produto(produtosDisponiveis[index]);

            Console.Clear();

            Console.WriteLine("V. Voltar");
            int quantidade = Helpers.LerInteiro(
                $"A quantidade máxima do produto {produto.Nome} é de {produto.Quantidade} unidades. Informe a quantidade desejada: "
            );
            if (quantidade == -1)
            {
                return;
            }
            if (quantidade > produto.Quantidade)
            {
                Console.WriteLine("Quantidade invalida");
                return;
            }
            produto.Quantidade = quantidade;

            if (!cliente.Carrinho.AdicionarProduto(produto))
            {
                if (Helpers.LerBool("Deseja esvaziar o carrinho?"))
                {
                    cliente.CriarNovoCarrinho();
                    cliente.Carrinho.AdicionarProduto(produto);
                }
                return;
            }

            Console.WriteLine("Produto adicionado ao carrinho!");
            Helpers.LerOpcaoSair();
        }
        public static void LimparCarrinho(Cliente cliente)
        {
            cliente.CriarNovoCarrinho();
            Console.WriteLine("Carrinho Limpo !!");
            Helpers.LerOpcaoSair();
        }
        public static void RemoverProdutoDoCarrinho(Cliente cliente, Produto produto)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Cliente não pode ser nulo.");
            if (produto == null)
                throw new ArgumentNullException(nameof(produto), "Produto não pode ser nulo.");
            cliente.Carrinho.RemoverProduto(produto);
        }
    }
}
