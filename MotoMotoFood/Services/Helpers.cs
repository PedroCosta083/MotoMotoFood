using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MotoMotoFood.Services
{
    public static class Helpers
    {
        public static string LerString(string mensagem)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada;

                Console.WriteLine("Entrada inválida! O valor não pode ser vazio.");
            }
        }

        public static string LerEmail(string mensagem)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && entrada.Contains("@"))
                {
                    return entrada;
                }

                Console.WriteLine("Entrada inválida! O valor não corresponde a um email válido.");
            }
        }
        public static string LerSenha(string mensagem)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && entrada.Length >= 6)
                    return entrada;

                Console.WriteLine("Entrada inválida! A senha deve ter pelo menos 6 caracteres.");
            }
        }

        public static decimal LerDecimal(string mensagem)
        {
            decimal valor;
            while (true)
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && decimal.TryParse(entrada, out valor))
                    return valor;

                Console.WriteLine("Valor inválido! Digite um número decimal válido.");
            }
        }

        public static int LerInteiro(string mensagem)
        {
            int valor;
            while (true)
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && int.TryParse(entrada, out valor))
                    return valor;

                Console.WriteLine("Valor inválido! Digite um número inteiro válido.");
            }
        }

        public static string LerCnpj(string mensagem)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && ValidarCNPJ(entrada))
                    return entrada;

                Console.WriteLine("Entrada inválida! CNPJ inválido.");
            }
        }

        public static string LerCpf(string mensagem)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && ValidarCPF(entrada))
                    return entrada;

                Console.WriteLine("Entrada inválida! CPF inválido.");
            }
        }

        public static string LerPlaca(string mensagem)
        {
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada) && ValidarPlaca(entrada))
                    return entrada;

                Console.WriteLine("Entrada inválida! CNPJ inválido.");
            }
        }

        private static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11 || new string(cpf[0], 11) == cpf)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }
        private static bool ValidarCNPJ(string cnpj)
        {
            return cnpj.Length == 14 && long.TryParse(cnpj, out _);
        }
        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            string padraoAntigo = @"^[A-Z]{3}-\d{4}$"; // Ex: ABC-1234
            string padraoMercosul = @"^[A-Z]{3}\d[A-Z]\d{2}$"; // Ex: ABC1D23

            return Regex.IsMatch(placa, padraoAntigo) || Regex.IsMatch(placa, padraoMercosul);
        }

    }
}
