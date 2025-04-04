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
    }
}
