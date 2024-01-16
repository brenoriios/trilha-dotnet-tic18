namespace TechMed.WebAPI;
public class Doctor
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Crm { get; set; }
    public required string Speciality { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
