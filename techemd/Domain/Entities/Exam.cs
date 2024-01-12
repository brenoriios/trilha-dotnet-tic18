namespace Techmed.Domain.Entities;
public class Exam : BaseEntity
{
    public required string Name { get; set; }
    public required float Price { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
