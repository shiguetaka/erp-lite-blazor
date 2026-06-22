using ERP.Application.DTOs;

namespace ERP.Web.Services;

public class VendaApiService
{
    private readonly HttpClient _http;

    public VendaApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("ERP.API");
    }

    public async Task<List<VendaDto>> GetVendasAsync()
    {
        return await _http.GetFromJsonAsync<List<VendaDto>>("api/vendas")
            ?? new();
    }

    public async Task CreateAsync(VendaDto venda)
    {
        await _http.PostAsJsonAsync("api/vendas", venda);
    }

    public async Task UpdateAsync(VendaDto venda)
    {
        await _http.PutAsJsonAsync("api/vendas", venda);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _http.DeleteAsync($"api/vendas/{id}");
    }

    public async Task<int> CountAsync()
    {
        return await _http.GetFromJsonAsync<int>("api/vendas/count");
    }
}