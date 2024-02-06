namespace TechMed.Domain.Entities;
public class Paciente : Pessoa
{
    public int PacienteId { get; set; }
    public required DateTimeOffset DataNascimento { get; set; }
}
