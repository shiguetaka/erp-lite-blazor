using ERP.Application.DTOs;
using System.Net.Http.Json;

namespace ERP.Web.Services;

public class ProdutoApiService
{

    private readonly HttpClient _http;

    public ProdutoApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("ERP.API");
    }

    public async Task<List<ProdutoDto>> GetProdutosAsync()
    {
        return await _http.GetFromJsonAsync<List<ProdutoDto>>("api/produtos")
            ?? new();
    }

    public async Task CreateAsync(ProdutoDto produto)
    {
        await _http.PostAsJsonAsync("api/produtos", produto);
    }

    public async Task UpdateAsync(ProdutoDto produto)
    {
        await _http.PutAsJsonAsync("api/produtos", produto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _http.DeleteAsync($"api/produtos/{id}");
    }

    public async Task<int> CountAsync()
    {
        return await _http.GetFromJsonAsync<int>("api/produtos/count");
    }
}