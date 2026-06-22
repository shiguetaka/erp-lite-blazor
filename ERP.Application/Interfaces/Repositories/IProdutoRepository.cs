using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(Guid id);
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(Produto produto);
    Task<int> CountAsync();
}