using System;
using MotoMotoFood.Models;

namespace DeliveryConsoleApp.Services
{
    public static class EntregadorService
    {
        public static void MenuEntregador(Entregador entregador)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Entregador ===");
                Console.WriteLine("1. Ver Entregas");
                Console.WriteLine("2. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                if (opcao == "2") break;
            }
        }
    }
}
