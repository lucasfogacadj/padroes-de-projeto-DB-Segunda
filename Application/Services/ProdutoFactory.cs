namespace Application.Services;

public static class ProdutoFactory
{
    public static Produto Criar(string nome, string descricao, decimal preco, int estoque)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do produto é obrigatório.", nameof(nome));

        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("A descrição do produto é obrigatória.", nameof(descricao));

        if (preco <= 0)
            throw new ArgumentException("O preço deve ser maior que zero.", nameof(preco));

        if (estoque < 0)
            throw new ArgumentException("O estoque não pode ser negativo.", nameof(estoque));
        var produto = new Produto();
        produto.Nome = nome;
        produto.Descricao = descricao;
        produto.Preco = preco;
        produto.Estoque = estoque;
        return produto;
    }
}
