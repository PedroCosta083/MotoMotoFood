using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotoMotoFood.Models;

namespace MotoMotoFood.Services
{
    class ContaService
    {
        public static void MenuContaComercial(Conta conta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Cliente ===");
                Console.WriteLine("1. Visualizar saldo");
                Console.WriteLine("2. Sacar");
                Console.WriteLine("3. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        MenuVisualizarSaldo(conta);
                        break;
                    case "2":
                        MenuSacar(conta);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void MenuSacar(Conta conta)
        {
            Helpers.LerValorParaSaque("Informe o valor para saque: ", conta);
        }

        private static void MenuVisualizarSaldo(Conta conta)
        {
            Console.WriteLine("=== Saldo Conta ===");
            Console.WriteLine(conta.ObterSaldoFormatado());
            Helpers.LerOpcaoSair();
        }
    }
}
