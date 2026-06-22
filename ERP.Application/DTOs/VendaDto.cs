namespace ERP.Application.DTOs;

public class VendaDto
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid ProdutoId { get; set; }
    public int? Quantidade { get; set; }
    public decimal? ValorUnitario { get; set; }
    public DateTime DataVenda { get; set; }
    public string? ClienteNome { get; set; }
    public string? ProdutoNome { get; set; }
}