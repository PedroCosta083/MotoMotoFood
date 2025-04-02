using System;
using System.Text.RegularExpressions;

namespace MotoMotoFood.Models
{
    public class Entregador : Usuario
    {
        public string CPF { get; private set; }
        public string Placa { get; private set; }
        public bool Disponivel { get; private set; } = true;

        public Entregador(string nome, string email, string senha, Endereco endereco, string telefone, string cpf, string placa)
            : base(nome, email, senha, endereco, telefone)
        {
            CPF = cpf;
            Placa = placa;
        }

        public void AlterarDisponibilidade(bool disponivel)
        {
            Disponivel = disponivel;
        }

       }
}
