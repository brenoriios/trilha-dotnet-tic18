namespace TechMed.WebAPI;
public class Patient : Person
{
    public required string Address { get; set; }
    public string? Phone { get; set; }
}
