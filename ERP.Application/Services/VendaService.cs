using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;

namespace ERP.Application.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _repository;

    public VendaService(IVendaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<VendaDto>> GetAllAsync()
    {
        var vendas = await _repository.GetAllAsync();

        return vendas.Select(x => new VendaDto
        {
            Id = x.Id,
            ClienteId = x.ClienteId,
            ProdutoId = x.ProdutoId,
            Quantidade = x.Quantidade,
            ValorUnitario = x.ValorUnitario,
            DataVenda = x.DataVenda,
            ClienteNome = x.Cliente?.Nome,
            ProdutoNome = x.Produto?.Nome
        }).ToList();
    }

    public async Task<VendaDto?> GetByIdAsync(Guid id)
    {
        var venda = await _repository.GetByIdAsync(id);

        if (venda == null)
            return null;

        return new VendaDto
        {
            Id = venda.Id,
            ClienteId = venda.ClienteId,
            ProdutoId = venda.ProdutoId,
            Quantidade = venda.Quantidade,
            ValorUnitario = venda.ValorUnitario,
            DataVenda = venda.DataVenda,
            ClienteNome = venda.Cliente.Nome,
            ProdutoNome = venda.Produto.Nome
        };
    }

    public async Task<VendaDto> CreateAsync(VendaDto venda)
    {
        var entity = new Domain.Entities.Venda
        {
            ClienteId = venda.ClienteId,
            ProdutoId = venda.ProdutoId,
            Quantidade = venda.Quantidade,
            ValorUnitario = venda.ValorUnitario,
            DataVenda = venda.DataVenda
        };

        await _repository.CreateAsync(entity);

        venda.Id = entity.Id;

        return venda;
    }

    public async Task UpdateAsync(VendaDto venda)
    {
        var entity = new Domain.Entities.Venda
        {
            Id = venda.Id,
            ClienteId = venda.ClienteId,
            ProdutoId = venda.ProdutoId,
            Quantidade = venda.Quantidade,
            ValorUnitario = venda.ValorUnitario,
            DataVenda = venda.DataVenda
        };

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var venda = await _repository.GetByIdAsync(id);

        if (venda != null)
            await _repository.DeleteAsync(venda);
    }

    public async Task<int> CountAsync()
    {
        return await _repository.CountAsync();
    }
}