using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;

namespace ERP.Application.Services;

public class VendaService : IVendaService
{
    private readonly IVendaRepository _repository;
    private readonly IProdutoRepository _produtoRepository;

    public VendaService(IVendaRepository repository,IProdutoRepository produtoRepository)
    {
        _repository = repository;
        _produtoRepository = produtoRepository;
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
        var produto = await _produtoRepository.GetByIdAsync(venda.ProdutoId);

        if(produto == null)
            throw new Exception("Produto não encontrado");

        if(produto.Estoque < venda.Quantidade)
            throw new Exception("Estoque insuficiente");

        produto.Estoque -= venda.Quantidade ?? 0;

        await _produtoRepository.UpdateAsync(produto);

        var entity = new Domain.Entities.Venda
        {
            ClienteId = venda.ClienteId,
            ProdutoId = venda.ProdutoId,
            Quantidade = venda.Quantidade ?? 0,
            ValorUnitario = produto.Preco,
            DataVenda = DateTime.Now
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
            Quantidade = venda.Quantidade ?? 0,
            ValorUnitario = venda.ValorUnitario ?? 0,
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