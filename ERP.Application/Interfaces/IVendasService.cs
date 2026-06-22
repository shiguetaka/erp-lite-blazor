using ERP.Application.DTOs;

namespace ERP.Application.Interfaces;

public interface IVendaService
{
    Task<List<VendaDto>> GetAllAsync();
    Task<VendaDto?> GetByIdAsync(Guid id);
    Task<VendaDto> CreateAsync(VendaDto venda);
    Task UpdateAsync(VendaDto venda);
    Task DeleteAsync(Guid id);
    Task<int> CountAsync();
}