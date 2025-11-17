using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

// TODO (Grupo Service): Implementar regras de negócio aqui.
// NÃO colocar detalhes de EF Core. Usar apenas a abstração IProdutoRepository.
// Integrar posteriormente com validações (FluentValidation) e Factory.
// Sugerido: lançar exceções de domínio específicas ou retornar Result Pattern (opcional, comentar no PR).
public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Produto>> ListarAsync(CancellationToken ct = default)
    {
        return await _repo.GetAllAsync(ct);
    }

    public async Task<Produto?> ObterAsync(int id, CancellationToken ct = default)
    {
        if (id <= 0)
            throw new ArgumentException("ID inválido");

        return await _repo.GetByIdAsync(id, ct);
    }

    public async Task<ProdutoReadDto> CriarAsync(string nome, string descricao, decimal preco, int estoque, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório");

        if (preco <= 0)
            throw new ArgumentOutOfRangeException("Preço deve ser maior que zero");

        if (estoque < 0)
            throw new ArgumentOutOfRangeException("Estoque não pode ser negativo");

        // Criação do produto via Factory
        var produto = ProdutoFactory.Criar(nome.Trim(), descricao?.Trim() ?? "", preco, estoque);

        await _repo.AddAsync(produto, ct);
        return MappingExtensions.ToReadDto(produto);
    }

    public async Task<bool> RemoverAsync(int id, CancellationToken ct = default)
    {
        var produto = await _repo.GetByIdAsync(id, ct);
        if(produto == null) return false;
        await _repo.RemoveAsync(produto);
        return true;
    }

    public async Task<Produto> AtualizarAsync(int id, Produto produto, CancellationToken ct = default)
    {
        var produtoEncontrado = await _repo.GetByIdAsync(id, ct);
        if (produtoEncontrado == null) return null;
        produtoEncontrado.Nome = produto.Nome;
        produtoEncontrado.Descricao = produto.Descricao;
        produtoEncontrado.Preco = produto.Preco;
        produtoEncontrado.Estoque = produto.Estoque;

        await _repo.UpdateAsync(produtoEncontrado, ct);
        await _repo.SaveChangesAsync(ct);
        return produtoEncontrado;
    
    }

    public async Task<ProdutoCreateDto?> AtualizarParcialAsync(int id, Produto produto, CancellationToken ct = default)
    {
        var produtoAtualizado = await _repo.GetByIdAsync(id, ct);
        if (produtoAtualizado == null) return null;
        if (!String.IsNullOrWhiteSpace(produto.Nome))
        {
            produtoAtualizado.Nome = produto.Nome;
        }
        if (!String.IsNullOrWhiteSpace(produto.Descricao))
        {
            produtoAtualizado.Descricao = produto.Descricao;
        }
        if (produto.Preco != 0)
        {
            produtoAtualizado.Preco = produto.Preco;
        }
        if (produto.Estoque != 0)
        {
            produtoAtualizado.Estoque = produto.Estoque;
        }

        await _repo.UpdateAsync(produtoAtualizado, ct);
        await _repo.SaveChangesAsync(ct);
        return MappingExtensions.ToCreateDto(produtoAtualizado);
    }


}
