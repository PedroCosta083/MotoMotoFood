using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace MotoMotoFood.Models
{
    public abstract class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }

        private byte[] senhaHash;

        private byte[] senhaSalt;

        public string Password { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public Conta Conta { get; private set; }

        public Usuario(string nome, string email, string password, Endereco endereco, string telefone)
        {
            Nome = nome;
            Email = email;
            GerarHashSenha(password);
            Endereco = endereco;
            Telefone = telefone;
            Conta = new Conta();
        }
        public void GerarHashSenha(string senha)
        {
            using (HMACSHA256 hmac = new HMACSHA256())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            }
        }

        public bool VerificarSenha(string senhaTentativa)
        {
            using (HMACSHA256 hmac = new HMACSHA256(senhaSalt))
            {
                byte[] hashTentativa = hmac.ComputeHash(Encoding.UTF8.GetBytes(senhaTentativa));
                return StructuralComparisons.StructuralEqualityComparer.Equals(hashTentativa, senhaHash);
            }
        }
    }
}
