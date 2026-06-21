using ERP.Application.DTOs;

namespace ERP.Web.Services;

public class ClienteApiService
{
    private readonly HttpClient _http;

    public ClienteApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("ERP.API");
    }

    public async Task<List<ClienteDto>> GetClientesAsync()
    {
        return await _http.GetFromJsonAsync<List<ClienteDto>>("api/clientes")
               ?? new List<ClienteDto>();
    }

    public async Task CreateAsync(ClienteDto cliente)
    {
        await _http.PostAsJsonAsync("api/clientes", cliente);
    }

    public async Task UpdateAsync(ClienteDto cliente)
    {
        await _http.PutAsJsonAsync("api/clientes", cliente);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _http.DeleteAsync($"api/clientes/{id}");
    }

    public async Task<int> CountAsync()
    {
        return await _http.GetFromJsonAsync<int>("api/clientes/count");
    }
}