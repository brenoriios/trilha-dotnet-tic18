namespace OrdemDeServico.WebAPI.InputModels;

public class NewServicoInputModel
{
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public required float Preco { get; set; }
}
