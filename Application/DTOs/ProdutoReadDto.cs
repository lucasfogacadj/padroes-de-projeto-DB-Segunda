namespace Application.DTOs
{
    // DTO para retorno de dados ao cliente (saída da API)
    public record ProdutoReadDto(
        int Id,
        string Nome,
        string Descricao,
        decimal Preco,
        int Estoque,
        DateTime DataCriacao
    );
}
