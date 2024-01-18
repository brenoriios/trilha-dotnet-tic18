namespace ResTIConnect.Domain.Entities;
public class Log : BaseEntity
{
    public int LogId { get; set; }
    public required string Tipo { get; set; }
    public required string Descricao { get; set; }
    public required DateTime DataHoraEvento { get; set; }
    public required string Entidade { get; set; }
    public required int TuplaId { get; set; }
}
