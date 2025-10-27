namespace Application.DTOs
{
    // DTO para criação de produto (entrada da API)
    // Mantém apenas os dados necessários para criar um produto
    public record ProdutoCreateDto(
        string Nome,
        string Descricao,
        decimal Preco,
        int Estoque
    );
}
