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

        public bool Depositar(decimal valor)
        {
            Saldo += valor;
            DataUltimoDeposito = DateTime.Now;
            return true;
        }

        public bool DeduzirSaldo(decimal valor)
        {
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
