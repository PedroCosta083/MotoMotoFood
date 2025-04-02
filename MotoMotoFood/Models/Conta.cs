using System;

namespace MotoMotoFood.Models
{
    public class Conta
    {
        public decimal Saldo { get; private set; }
        public DateTime? DataUltimoDeposito { get; private set; }
        public DateTime? DataUltimoDebito { get; private set; }

        public Conta()
        {
            Saldo = 0;
        }

        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do depósito deve ser positivo.");

            Saldo += valor;
            DataUltimoDeposito = DateTime.Now;
        }

        public bool DeduzirSaldo(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor do débito deve ser positivo.");

            if (Saldo >= valor)
            {
                Saldo -= valor;
                DataUltimoDebito = DateTime.Now;
                return true;
            }
            return false;
        }

        public string ObterSaldoFormatado()
        {
            return Saldo.ToString("C");
        }
    }
}
