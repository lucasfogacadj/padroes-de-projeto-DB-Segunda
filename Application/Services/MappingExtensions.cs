using Application.DTOs;
using Domain.Entities;

namespace Application.Services
{
    public static class MappingExtensions
    {
        // converte entidade em DTO de leitura
        public static ProdutoReadDto ToReadDto(this Produto p)
        {
            return new ProdutoReadDto(
                p.Id,
                p.Nome,
                p.Descricao,
                p.Preco,
                p.Estoque,
                p.DataCriacao
            );
        }
        public static ProdutoCreateDto ToCreateDto(this Produto p)
        {
            return new ProdutoCreateDto(
                p.Nome,
                p.Descricao,
                p.Preco,
                p.Estoque
            );
        }

        // converte DTO de criação em entidade
        public static Produto ToEntity(this ProdutoCreateDto dto)
        {
            return new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Estoque = dto.Estoque,
                DataCriacao = DateTime.UtcNow
            };
        }
        
    }
}
