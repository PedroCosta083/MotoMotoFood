using System;

namespace MotoMotoFood.Models
{
    public abstract class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public Conta Conta { get; private set; }

        public Usuario(string nome, string email, string password, Endereco endereco, string telefone)
        {
            Nome = nome;
            Email = email;
            Password = password;
            Endereco = endereco;
            Telefone = telefone;
            Conta = new Conta();
        }

        public bool VerificarSenha(string senha)
        {
            return senha == Password;
        }
    }
}
