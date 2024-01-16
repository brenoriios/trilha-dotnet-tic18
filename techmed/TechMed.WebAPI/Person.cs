namespace TechMed.WebAPI;
public class Person
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}
