using ERP.Application.DTOs;

namespace ERP.Application.Interfaces;

public interface IProdutoService
{
    Task<List<ProdutoDto>> GetAllAsync();
    Task CreateAsync(ProdutoDto produto);
    Task UpdateAsync(ProdutoDto produto);
    Task DeleteAsync(Guid id);
    Task<int> CountAsync();
}