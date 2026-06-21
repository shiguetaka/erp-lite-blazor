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
}