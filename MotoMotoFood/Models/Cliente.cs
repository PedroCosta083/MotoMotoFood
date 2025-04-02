using System;

namespace MotoMotoFood.Models
{
    public class Cliente : Usuario
    {
        public Carrinho Carrinho { get; private set; }

        public Cliente(string nome, string email, string password, Endereco endereco, string telefone)
            : base(nome, email, password, endereco, telefone)
        {
            Carrinho = new Carrinho();
        }

        public void CriarNovoCarrinho()
        {
            Carrinho = new Carrinho();
        }
    }
}
