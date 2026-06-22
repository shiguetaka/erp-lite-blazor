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
    public async Task<ActionResult<List<ProdutoDto>>> Get()
    {
        var produtos = await _service.GetAllAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProdutoDto>> GetById(Guid id)
    {
        var produto = await _service.GetByIdAsync(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDto>> Create(ProdutoDto produto)
    {
        var result = await _service.CreateAsync(produto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> Update(ProdutoDto produto)
    {
        await _service.UpdateAsync(produto);
        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> Count()
    {
        var total = await _service.CountAsync();
        return Ok(total);
    }
}