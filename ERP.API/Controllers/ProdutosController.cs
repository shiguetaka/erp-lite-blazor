using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var produtos = await _service.GetAllAsync();

        return Ok(produtos);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProdutoDto produto)
    {
        await _service.CreateAsync(produto);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(ProdutoDto produto)
    {
        await _service.UpdateAsync(produto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }

    [HttpGet("count")]
    public async Task<IActionResult> Count()
    {
        var total = await _service.CountAsync();
        return Ok(total);
    }
}