namespace Techmed.Domain.Entities;
public class Appointment : BaseEntity
{
    public required Patient Patient { get; set; }
    public required int PatientId { get; set; }
    public required Doctor Doctor { get; set; }
    public required int DoctorId { get; set; }
    public ICollection<Exam>? Exams { get; set; }
    public required DateTime Date { get; set; }
}
