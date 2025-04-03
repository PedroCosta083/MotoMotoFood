using System;
using System.Linq;
using MotoMotoFood.Models;
using MotoMotoFood.Services;

namespace DeliveryConsoleApp.Services
{
    public static class RestauranteService
    {
        public static void MenuRestaurante(Restaurante restaurante)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Restaurante ===");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Visualizar produtos");
                Console.WriteLine("3. Remover Produto");
                Console.WriteLine("4. Editar Produto");
                Console.WriteLine("5. Gerenciar Conta");
                Console.WriteLine("6. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        MenuCadastrarProduto(restaurante);
                        break;
                    case "2":
                        MenuVisualizarProdutos(restaurante);
                        break;
                    case "3":
                        MenuRemoverProduto(restaurante);
                        break;
                    case "4":
                        MenuEditarProduto(restaurante.Produtos);
                        break;
                    case "5":
                        ContaService.MenuContaComercial(restaurante.Conta);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;

                }
            }
        }

        private static void MenuCadastrarProduto(Restaurante restaurante)
        {
            Console.Clear();
            Console.WriteLine("=== Adicioar Produto ===");
            try
            {
                var nome = Helpers.LerString("Nome do produto: ");
                var descricao = Helpers.LerString("Descricao do produto: ");
                var preco = Helpers.LerDecimal("Preço: ");
                var quantidade = Helpers.LerInteiro("Quantidade: ");
                var tempoPreparo = Helpers.LerInteiro("Tempo de preparo (Em minutos): ");
                CadastrarProduto(nome, descricao, preco, quantidade, tempoPreparo, restaurante);
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("Tente novamente.");
                Console.ReadKey();
                MenuCadastrarProduto(restaurante);
            }
        }

        private static void CadastrarProduto(string nome, string descricao, decimal preco, int quantidade, int tempoPreparo, Restaurante restaurante)
        {
            var produto = new Produto
                (
                    nome,
                    preco,
                    descricao,
                    quantidade,
                    tempoPreparo
                );
            restaurante.Produtos.Add(produto);
        }

        private static void MenuVisualizarProdutos(Restaurante restaurante)
        {
            Console.Clear();
            restaurante.ListarProdutos();
        }

        private static void MenuRemoverProduto(Restaurante restaurante)
        {
            int index = Helpers.LerOpcaoListaProdutos(restaurante.Produtos);
            restaurante.Produtos.RemoveAt(index);
            Console.WriteLine("Produto removido com sucesso!");
            Helpers.LerOpcaoSair();
        }

        private static void MenuEditarProduto(List<Produto> produtos)
        {
            Produto produtoEditado = produtos[Helpers.LerOpcaoListaProdutos(produtos)];
            produtoEditado.Nome = Helpers.LerString("Nome do produto: ");
            produtoEditado.Descricao = Helpers.LerString("Descricao do produto: ");
            produtoEditado.Preco = Helpers.LerDecimal("Preço: ");
            produtoEditado.Quantidade = Helpers.LerInteiro("Quantidade: ");
            produtoEditado.TempoPreparo = Helpers.LerInteiro("Tempo de preparo (Em minutos): ");
            Console.WriteLine("Produto editado com sucesso!");
            Helpers.LerOpcaoSair();
        }

    }
}
