namespace ERP.Domain.Entities;

public class Venda
{
    public Guid Id { get; set; }
    public Guid ClienteId { get; set; }
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public DateTime DataVenda { get; set; }
    
    public Cliente Cliente { get; set; } = null!;
    public Produto Produto { get; set; } = null!;
}