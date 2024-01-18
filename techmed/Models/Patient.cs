namespace TechMed.WebAPI.Model;
public class Patient : Person
{
    public int PatientId { get; set; }
    public required string Address { get; set; }
    public string? Phone { get; set; }
}
