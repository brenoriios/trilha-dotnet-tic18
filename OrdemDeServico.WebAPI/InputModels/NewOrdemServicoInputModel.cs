namespace OrdemDeServico.WebAPI;

public class NewOrdemServicoInputModel
{
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required DateTimeOffset DataDeEmissao { get; set; }
    public required string Status { get; set; }
    public int ClienteId { get; set; }
    public int PrestadorId { get; set; }
    public required NewServicoInputModel Servico { get; set; }
}
