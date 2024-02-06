using TechMed.Domain.Entities.Common;

namespace TechMed.Domain.Entities;
public class Exame : BaseEntity
{
    public int ExameId { get; set; }
    public required string Nome { get; set; }
    public required DateTimeOffset DataHora { get; set; }
    public required float Valor { get; set; }
    public required string Local { get; set; }
    public required string ResultadoDescricao { get; set; }
}
