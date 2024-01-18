namespace TechMed.WebAPI.Model;
public class Doctor : Person
{
    public int DoctorId { get; set; }
    public required string Crm { get; set; }
    public required float Salary { get; set; }
    public string? Specialization { get; set; }
}
