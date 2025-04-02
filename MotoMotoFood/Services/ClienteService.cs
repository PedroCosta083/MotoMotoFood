using MotoMotoFood.Models;
using MotoMotoFood.Services;

namespace DeliveryConsoleApp.Services
{
    public static class ClienteService
    {
        public static void MenuCliente(Cliente cliente, List<Restaurante> restaurantes)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Cliente ===");
                Console.WriteLine("1. Visualizar Restaurantes");
                Console.WriteLine("2. Visualizar Carrinho");
                Console.WriteLine("3. Visualizar Conta");
                Console.WriteLine("4. Visualizar Pedidos");
                Console.WriteLine("5. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        VisualizarRestaurantes(cliente, restaurantes);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void VisualizarRestaurantes(Cliente cliente, List<Restaurante> restaurantes)
        {
            Console.Clear();
            Console.WriteLine("=== Restaurantes Disponíveis ===");
            for (int i = 0; i < restaurantes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurantes[i].NomeEstabelecimento}");
            }

            Console.Write("Escolha um restaurante: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= restaurantes.Count)
            {
                VisualizarProdutos(restaurantes[escolha - 1], cliente);
            }
        }

        private static void VisualizarProdutos(Restaurante restaurante, Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine($"=== Produtos de {restaurante.NomeEstabelecimento} ===");
            for (int i = 0; i < restaurante.Produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {restaurante.Produtos[i].Nome} - R${restaurante.Produtos[i].Preco}");
            }

            Console.WriteLine("0. sair");
            if (int.TryParse(Helpers.LerString("Escolha um produto para adicionar ao carrinho: "), out int escolha) && escolha > 0 && escolha <= restaurante.Produtos.Count)
            {
                cliente.Carrinho.AdicionarProduto(restaurante.Produtos[escolha - 1]);
                Console.WriteLine("Produto adicionado ao carrinho!");
                Console.ReadLine();
            }
        }



    }
}
