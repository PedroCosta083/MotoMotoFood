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
            int index = Helpers.LerInteiroComValorMaximo("Escolha um produto para adicionar ao carrinho: ", restaurante.Produtos.Count);
            Produto produto = restaurante.Produtos[index];
            Console.Clear();
            int quantidade = Helpers.LerInteiroComValorMaximo($"A quantidade máxima do produto {produto.Nome} é de {produto.Quantidade} unidades. Informe  a quantidade desejada: ", produto.Quantidade);
            produto.Quantidade = quantidade;
            cliente.Carrinho.AdicionarProduto(produto);
            Console.WriteLine("Produto adicionado ao carrinho!");
            Helpers.LerOpcaoSair();
        }



    }
}
