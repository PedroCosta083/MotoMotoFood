using MotoMotoFood.Models;

public class Restaurante : Usuario
{
    public string NomeEstabelecimento { get; }
    public string CNPJ { get; }
    public List<Produto> Produtos { get; }

    public Restaurante(string nome, string nomeEstabelecimento, string email, string password, Endereco endereco, string telefone, string cnpj)
        : base(nome, email, password, endereco, telefone)
    {
        NomeEstabelecimento = nomeEstabelecimento;
        CNPJ = cnpj;
        Produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        if (produto == null)
            throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");

        Produtos.Add(produto);
    }

    public bool RemoverProduto(Produto produto)
    {
        return Produtos.Remove(produto);
    }

    public void ListarProdutos()
    {
        Console.WriteLine($"Produtos do restaurante {NomeEstabelecimento}:");
        foreach (var produto in Produtos)
        {
            Console.WriteLine($"- {produto.Nome}: {produto.Preco:C}");
        }
    }

}
