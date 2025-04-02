using System;
using System.Collections.Generic;
using DeliveryConsoleApp.Services;
using MotoMotoFood.Models;
using MotoMotoFood.Services;

namespace DeliveryConsoleApp
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Restaurante> restaurantes = new List<Restaurante>();
        static List<Entregador> entregadores = new List<Entregador>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Delivery ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Cadastrar-se");
                Console.WriteLine("3. Sair");
                //Console.Write("Escolha uma opção: ");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        AutenticacaoService.Login(clientes, restaurantes, entregadores);
                        break;
                    case "2":
                        AutenticacaoService.Cadastrar(clientes,restaurantes,entregadores);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
