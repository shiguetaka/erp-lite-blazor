using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class VendaRepository : IVendaRepository
{
    private readonly ERPDbContext _context;

    public VendaRepository(ERPDbContext context)
    {
        _context = context;
    }

    public async Task<List<Venda>> GetAllAsync()
    {
        return await _context.Vendas
            .Include(x => x.Cliente)
            .Include(x => x.Produto)
            .ToListAsync();
    }

    public async Task<Venda?> GetByIdAsync(Guid id)
    {
        return await _context.Vendas
            .Include(x => x.Cliente)
            .Include(x => x.Produto)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(Venda venda)
    {
        _context.Vendas.Add(venda);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Venda venda)
    {
        _context.Vendas.Update(venda);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Venda venda)
    {
        _context.Vendas.Remove(venda);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Vendas.CountAsync();
    }
}