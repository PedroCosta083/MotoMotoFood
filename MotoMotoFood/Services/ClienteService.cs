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
                Console.WriteLine("3. Gerenciar Conta");
                Console.WriteLine("4. Visualizar Pedidos");
                Console.WriteLine("5. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        VisualizarRestaurantes(cliente, restaurantes);
                        break;
                    case "2":
                        VisualizarCarrinho(cliente);
                        break;
                    case "3":
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

            var produtosDisponiveis = restaurante.Produtos
                .Where(p => p.Quantidade > 0)
                .ToList();

            if (!produtosDisponiveis.Any())
            {
                Console.WriteLine("Nenhum produto disponível no momento.");
                Helpers.LerOpcaoSair();
                return;
            }

            for (int i = 0; i < produtosDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {produtosDisponiveis[i].Nome} - R${produtosDisponiveis[i].Preco} (Quantidade: {produtosDisponiveis[i].Quantidade})");
            }

            int index = Helpers.LerInteiroComValorMaximo("Escolha um produto para adicionar ao carrinho: ", produtosDisponiveis.Count);
            Produto produto = new Produto(produtosDisponiveis[index]);

            Console.Clear();
            int quantidade = Helpers.LerInteiroComValorMaximo(
                $"A quantidade máxima do produto {produto.Nome} é de {produto.Quantidade} unidades. Informe a quantidade desejada: ",
                produto.Quantidade
            );

            produto.Quantidade = quantidade;

            if (!cliente.Carrinho.AdicionarProduto(produto))
            {
                Console.WriteLine("Você só pode adicionar produtos do mesmo restaurante ao carrinho!");
                Console.WriteLine("Seu carrinho já contém produtos de outro restaurante.");

                if (Helpers.LerBool("Deseja esvaziar o carrinho?"))
                {
                    cliente.CriarNovoCarrinho();
                    cliente.Carrinho.AdicionarProduto(produto);
                }
                Helpers.LerOpcaoSair();
            }

            Console.WriteLine("Produto adicionado ao carrinho!");
            Helpers.LerOpcaoSair();
        }

        private static void VisualizarCarrinho(Cliente cliente)
        {

        }



    }
}
