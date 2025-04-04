using System;
using System.Collections.Generic;
using MotoMotoFood.Models;
using MotoMotoFood.Services;

namespace DeliveryConsoleApp.Services
{
    public static class AutenticacaoService
    {
        public static void Login(List<Usuario>usuarios)
        {
            string email = Helpers.LerEmail("Digite seu email: ");
            string password = Helpers.LerString("Digite sua senha: ");

            var usuario = usuarios.Find(c => c.Email == email);
            switch (usuario)
            {
                case Restaurante restaurante:
                        RestauranteService.MenuRestaurante(restaurante);
                        return;
                case Cliente cliente:

                    ClienteService.MenuCliente(cliente, usuarios.OfType<Restaurante>().ToList());
                    return;
                case Entregador entregador:
                    EntregadorService.MenuEntregador(entregador);
                    return;
            }

            Console.WriteLine("Usuário nao encontrado!");
            Console.WriteLine("Aperte ENTER para reiniciar");
            Console.ReadLine();
        }

        private static (string nome,string email,string senha,string telefone) BaseMenu()
        {
                string nome = Helpers.LerString("Nome do Usuario: ");
                string email = Helpers.LerEmail("Email: ");
                string senha = Helpers.LerSenha("Senha: ");
                string telefone = Helpers.LerString("Telefone: ");

                return (nome, email, senha, telefone);
        }
       
        private static Endereco MenuCadastroEndereco()
        {
            Console.WriteLine("=== Endereço ===");
            string rua = Helpers.LerString("Rua: ");
            string numero = Helpers.LerString("Numero: ");
            string cep = Helpers.LerString("CEP: ");

            var novoEndereco = new Endereco(rua, numero, cep);
            return novoEndereco;
        }
        public static void Cadastrar(List<Usuario> usuarios)
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO ===");
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Restaurante");
            Console.WriteLine("3. Entregador");
            Console.WriteLine("4. Voltar");
            string opcao = Helpers.LerString("Escolha o tipo de cadastro: ");

            switch (opcao)
            {
                case "1":
                    CadastrarCliente(usuarios);
                    break;
                case "2":
                    CadastrarRestaurante(usuarios);
                    break;
                case "3":
                    CadastrarEntregador(usuarios);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }
        }

        private static void CadastrarCliente(List<Usuario> clientes)
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE CLIENTE ===");

            var(nome,email,senha,telefone) = BaseMenu();
            var novoEndereco = MenuCadastroEndereco();

            var novoCliente = new Cliente
            (
                nome,
                email,
                senha,
                novoEndereco,
                telefone
            );

            clientes.Add(novoCliente);
            Console.WriteLine("\nCliente cadastrado com sucesso!");
            Console.WriteLine("\nAperte ENTER para continuar!");
            Console.ReadKey();
        }

        private static void CadastrarRestaurante(List<Usuario> restaurantes)
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE RESTAURANTE ===");

            var (nome, email, senha, telefone) = BaseMenu();
            string nomeEstabelecimento = Helpers.LerString("Nome do estabelecimento: ");

            string cnpj = Helpers.LerCnpj("CNPJ: ");
            var novoEndereco = MenuCadastroEndereco();

            var novoRestaurante = new Restaurante
            (
                nome,
                nomeEstabelecimento,
                email,
                senha,
                novoEndereco,
                cnpj,
                telefone
            );

            restaurantes.Add(novoRestaurante);
            Console.WriteLine("\nRestaurante cadastrado com sucesso!");
            Console.ReadKey();
        }

        private static void CadastrarEntregador(List<Usuario> entregadores)
        {
            Console.Clear();
            Console.WriteLine("=== CADASTRO DE ENTREGADOR ===");

            var (nome, email, senha, telefone) = BaseMenu();
            var novoEndereco = MenuCadastroEndereco();
            string cpf = Helpers.LerCpf("CPF: ");
            string placa = Helpers.LerPlaca("Placa do Veículo: ");

            var novoEntregador = new Entregador
            (
                nome,
                email,
                senha,
                novoEndereco,
                telefone,
                cpf,
                placa
            );

            entregadores.Add(novoEntregador);
            Console.WriteLine("\nEntregador cadastrado com sucesso!");
            Console.ReadKey();
        }
    }
}