using ERP.Application.DTOs;
using ERP.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendasController : ControllerBase
{
    private readonly IVendaService _service;

    public VendasController(IVendaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<VendaDto>>> Get()
    {
        var vendas = await _service.GetAllAsync();
        return Ok(vendas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VendaDto>> GetById(Guid id)
    {
        var venda = await _service.GetByIdAsync(id);

        if (venda == null)
            return NotFound();

        return Ok(venda);
    }

    [HttpPost]
    public async Task<ActionResult> Create(VendaDto venda)
    {
        await _service.CreateAsync(venda);
        return Ok(venda);
    }

    [HttpPut]
    public async Task<ActionResult> Update(VendaDto venda)
    {
        await _service.UpdateAsync(venda);
        return Ok(venda);
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