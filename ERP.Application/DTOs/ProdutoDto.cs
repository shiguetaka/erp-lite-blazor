namespace ERP.Application.DTOs;
public class ProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal? Preco { get; set; }
    public int? Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
}