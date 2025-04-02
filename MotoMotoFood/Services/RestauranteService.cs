using System;
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
                Console.WriteLine("4. Verificar Saldo");
                Console.WriteLine("5. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        MenuCadastrarProduto(restaurante);
                        break;
                    case "2":
                        //MenuVisualizarProdutos(restaurante);
                        break;
                    case "3":
                        //MenuRemoverProduto(restaurante);
                        break;
                    case "5":
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

    }
}
