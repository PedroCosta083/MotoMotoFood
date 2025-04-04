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
                Console.WriteLine("=== Menu Conta Restaurante ===");
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

        public static void MenuContaCliente(Conta conta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Conta Cliente ===");
                Console.WriteLine("1. Visualizar saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Sair");
                string opcao = Helpers.LerString("Escolha uma opção: ");

                switch (opcao)
                {
                    case "1":
                        MenuVisualizarSaldo(conta);
                        break;
                    case "2":
                        MenuDepositar(conta);
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

        private static void MenuDepositar(Conta conta)
        {
            Helpers.LerValorParaDeposito("Informe o valor para deposito ou 99999 para voltar: ", conta);
        }

        private static void MenuVisualizarSaldo(Conta conta)
        {
            Console.WriteLine("=== Saldo Conta ===");
            Console.WriteLine(conta.ObterSaldoFormatado());
            Helpers.LerOpcaoSair();
        }
    }
}
