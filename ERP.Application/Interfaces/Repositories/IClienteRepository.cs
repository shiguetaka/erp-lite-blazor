using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(Guid id);
    Task AddAsync(Cliente cliente);
    Task UpdateAsync(Cliente cliente);
    Task DeleteAsync(Cliente cliente);
    Task<int> CountAsync();
}