namespace Application.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;

public interface IProdutoService
{
    Task<IEnumerable<Produto>> ListarAsync(CancellationToken ct = default);
    Task<Produto?> ObterAsync(int id, CancellationToken ct = default);
    Task<ProdutoReadDto> CriarAsync(string nome, string descricao, decimal preco, int estoque, CancellationToken ct = default);
    Task<bool> RemoverAsync(int id, CancellationToken ct = default);
    Task<Produto> AtualizarAsync(int id, ProdutoCreateDto produto, CancellationToken ct = default);
    Task<ProdutoCreateDto?> AtualizarParcialAsync(int id, Produto produto, CancellationToken ct = default);
}
