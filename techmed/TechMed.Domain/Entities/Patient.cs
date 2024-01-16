namespace Techmed.Domain.Entities;
public class Patient : Person
{
    public required string Address { get; set; }
    public string? Phone { get; set; }
    public ICollection<Appointment>? Appointments { get; }
}
