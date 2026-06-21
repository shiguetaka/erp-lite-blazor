using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProdutoDto>> GetAllAsync()
    {
        var produtos = await _repository.GetAllAsync();

        return produtos.Select(p => new ProdutoDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Descricao = p.Descricao,
            Preco = p.Preco,
            Estoque = p.Estoque,
            DataCadastro = p.DataCadastro
        }).ToList();
    }

    public async Task CreateAsync(ProdutoDto produto)
    {
        var entity = new ERP.Domain.Entities.Produto
        {
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
        await _repository.AddAsync(entity);
    }

    public async Task UpdateAsync(ProdutoDto produto)
    {
        var entity = new ERP.Domain.Entities.Produto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<int> CountAsync()
    {
        return await _repository.CountAsync();
    }
}