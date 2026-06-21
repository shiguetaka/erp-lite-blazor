using ERP.Application.DTOs;

namespace ERP.Application.Interfaces;

public interface IClienteService
{
    Task<List<ClienteDto>> GetAllAsync();
    Task<ClienteDto?> GetByIdAsync(Guid id);
    Task<ClienteDto> CreateAsync(ClienteDto cliente);
    Task UpdateAsync(ClienteDto cliente);
    Task DeleteAsync(Guid id);
    Task<int> CountAsync();
}