namespace Techmed.Domain.Entities;
public class Doctor : Person
{
    public required string Crm { get; set; }
    public required float Salary { get; set; }
    public string? Specialization { get; set; }
    public ICollection<Appointment>? Appointments { get; }
}
