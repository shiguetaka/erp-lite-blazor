using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using ERP.Application.Interfaces.Repositories;
using ERP.Domain.Entities;

namespace ERP.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repository.GetAllAsync();

        return clientes.Select(x => new ClienteDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Email = x.Email,
            Telefone = x.Telefone
        }).ToList();
    }

    public async Task<ClienteDto?> GetByIdAsync(Guid id)
    {
        var cliente = await _repository.GetByIdAsync(id);

        if (cliente == null)
            return null;

        return new ClienteDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone
        };
    }

    public async Task<ClienteDto> CreateAsync(ClienteDto cliente)
    {
        var entity = new Cliente
        {
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone
        };

        await _repository.AddAsync(entity);

        cliente.Id = entity.Id;

        return cliente;
    }

    public async Task UpdateAsync(ClienteDto cliente)
    {
        var entity = await _repository.GetByIdAsync(cliente.Id);

        if (entity == null)
            return;

        entity.Nome = cliente.Nome;
        entity.Email = cliente.Email;
        entity.Telefone = cliente.Telefone;

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