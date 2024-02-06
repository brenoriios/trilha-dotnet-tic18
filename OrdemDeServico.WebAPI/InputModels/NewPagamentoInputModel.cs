namespace OrdemDeServico.WebAPI.InputModels;

public class NewPagamentoInputModel
{
    public required float Valor { get; set; }
    public required DateTimeOffset DataPagamento { get; set; }
    public required string MetodoPagamento { get; set; }
    public int OrdemServicoId { get; set; }
}
