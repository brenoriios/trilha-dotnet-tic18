namespace TechMed.Domain.Entities;
public class Atendimento
{
    public int AtendimentoId { get; set; }
    public required DateTimeOffset DataHoraInicio { get; set; }
    public required DateTimeOffset DataHoraFim { get; set; }
    public required string SuspeitaInicial { get; set; }
    public required string Diagnostico { get; set; }
}
