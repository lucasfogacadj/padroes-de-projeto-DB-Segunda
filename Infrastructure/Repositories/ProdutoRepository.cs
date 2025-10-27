using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Repositories;

// TODO (Grupo Repository): Implementar métodos usando AppDbContext.
// Focar em persistência apenas. NÃO adicionar regras de negócio.
// Discutir no PR: vantagens e possíveis redundâncias do padrão.

public class ProdutoRepository : IProdutoRepository
{

    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Produto>> GetAllAsync(CancellationToken ct = default)
    {
        // Permite consultar as entidades do banco de dados sem rastrear as suas entidades através do AsNoTracking, tendo mais desempenho quando precisa fazer leituras.
        return await _context.Produtos.AsNoTracking().ToListAsync(ct);
    }

    public async Task<Produto?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        // Busca uma entidade específica no banco de dados através do seu id usando FindAsync.
        return await _context.Produtos.FindAsync(id, ct);
    }

    public async Task AddAsync(Produto produto, CancellationToken ct = default)
    {
        // adiciona uma nova entidade ao banco de dados usando AddAsync.
        // salva as alterações que foram feitas ao banco de dados com SaveChangesAsync.
        await _context.Produtos.AddAsync(produto, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task RemoveAsync(Produto produto, CancellationToken ct = default)
    {
        // marca um produto como deleted através do Remove, mas ele é apagado do banco de dados apenas quando a alteração for salva com SaveChangesAsync.
        _context.Remove(produto);
        await _context.SaveChangesAsync(ct);
    }

    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _context.SaveChangesAsync(ct);
    }
}