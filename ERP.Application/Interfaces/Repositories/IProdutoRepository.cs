using ERP.Domain.Entities;

namespace ERP.Application.Interfaces.Repositories;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllAsync();
    Task AddAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(Guid id);
    Task<int> CountAsync();
}