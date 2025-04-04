using System;
using System.Collections.Generic;
using DeliveryConsoleApp.Services;
using MotoMotoFood.Models;
using MotoMotoFood.Services;

namespace DeliveryConsoleApp
{
    class Program
    {
        static List<Usuario> usuarios = new List<Usuario>();
        static void Main()
        {
            inicializar();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Delivery ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Cadastrar-se");
                Console.WriteLine("3. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        AutenticacaoService.Login(usuarios);
                        break;
                    case "2":
                        AutenticacaoService.Cadastrar(usuarios);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        public static void inicializar()
        {
            clientes.Add(new Cliente("j", "j@j", "mestre123", new Endereco("j", "j", "s"), "a"));
            restaurantes.Add(new Restaurante("j", "j@j", "j@jj", "mestre123", new Endereco("j", "j", "s"), "a", "12312312312345"));
            restaurantes[0].AdicionarProduto(new Produto("bolo", 12, "doce", 2, 20, restaurantes[0].Email));
            restaurantes.Add(new Restaurante("r", "r@r", "r@r", "mestre123", new Endereco("j", "j", "s"), "a", "12312312312345"));
            restaurantes[1].AdicionarProduto(new Produto("cafe", 12, "cafe", 2, 20, restaurantes[1].Email));
        }
    }
}
