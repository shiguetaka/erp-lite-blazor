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

    public async Task<ProdutoDto?> GetByIdAsync(Guid id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto == null)
            return null;

        return new ProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
    }

    public async Task<ProdutoDto> CreateAsync(ProdutoDto produto)
    {
        var entity = new Produto
        {
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };

        await _repository.AddAsync(entity);

        produto.Id = entity.Id;

        return produto;
    }

    public async Task UpdateAsync(ProdutoDto produto)
    {
        var entity = await _repository.GetByIdAsync(produto.Id);
        
        if (entity == null)
            return;
            
        entity.Nome = produto.Nome;
        entity.Descricao = produto.Descricao;
        entity.Preco = produto.Preco;
        entity.Estoque = produto.Estoque;
        
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            return;

        await _repository.DeleteAsync(entity);
    }

    public async Task<int> CountAsync()
    {
        return await _repository.CountAsync();
    }
}