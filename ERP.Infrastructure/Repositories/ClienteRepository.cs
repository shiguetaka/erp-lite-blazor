using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;
using ERP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly ERPDbContext _context;

    public ClienteRepository(ERPDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }
    
    public async Task<int> CountAsync()
    {
        return await _context.Clientes.CountAsync();
    }
}