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

    public async Task DeleteAsync(Guid id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if(produto != null)
        {
            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> CountAsync()
    {
        return await _context.Produtos.CountAsync();
    }
}