using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IVendaRepository
{
    Task<List<Venda>> GetAllAsync();
    Task<Venda?> GetByIdAsync(Guid id);
    Task CreateAsync(Venda venda);
    Task UpdateAsync(Venda venda);
    Task DeleteAsync(Venda venda);
    Task<int> CountAsync();
}