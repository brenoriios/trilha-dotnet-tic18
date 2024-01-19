namespace TechMed.WebAPI.Model;

public class Exame{
    public int ExameId {get; set;}
    public required string Local {get; set;}
    public DateTime DataHora {get; set;}
    public ICollection<Exame>? Atendimentos {get; set;}
}
