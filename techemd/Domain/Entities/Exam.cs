namespace Techmed.Domain.Entities;
public class Exam : BaseEntity
{
    public required string Name { get; set; }
    public required string Place { get; set; }
    public required float Price { get; set; }
    public required DateTime Date { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
