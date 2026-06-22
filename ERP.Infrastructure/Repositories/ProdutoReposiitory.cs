using ERP.Domain.Entities;
using ERP.Infrastructure.Data;
using ERP.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{

    private readonly ERPDbContext _context;

    public ProdutoRepository(ERPDbContext context)
    {
        _context = context;
    }

    public async Task<List<Produto>> GetAllAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    public async Task<Produto?> GetByIdAsync(Guid id)
    {
        return await _context.Produtos
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Produto produto)
    {
        await _context.Produtos.AddAsync(produto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Produto produto)
    {
        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();        
    }

    public async Task<int> CountAsync()
    {
        return await _context.Produtos.CountAsync();
    }
}