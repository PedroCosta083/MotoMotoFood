﻿using System;

namespace MotoMotoFood.Models
{
    public class Produto
    {
        public string Nome { get; }
        public decimal Preco { get; private set; }
        public string Descricao { get; }
        public int Quantidade { get; private set; }
        public int TempoPreparo { get; }

        public Produto(string nome, decimal preco, string descricao, int quantidade, int tempoPreparo)
        {
            Validate(nome,preco,quantidade,tempoPreparo);

            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Quantidade = quantidade;
            TempoPreparo = tempoPreparo;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            if (novoPreco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");

            Preco = novoPreco;
        }

        public void AtualizarQuantidade(int quantidade)
        {
            if (quantidade < 0)
                throw new ArgumentException("A quantidade não pode ser negativa.");

            Quantidade = quantidade;
        }

        public bool DeduzirEstoque(int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("A quantidade a ser removida deve ser maior que zero.");

            if (Quantidade >= quantidade)
            {
                Quantidade -= quantidade;
                return true;
            }
            return false;
        }

        private static void Validate(string nome,decimal preco, int quantidade, int tempoPreparo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto não pode ser vazio.");

            if (preco <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");

            if (quantidade < 0)
                throw new ArgumentException("A quantidade não pode ser negativa.");

            if (tempoPreparo < 0)
                throw new ArgumentException("O tempo de preparo não pode ser negativo.");
        }
    }
}
