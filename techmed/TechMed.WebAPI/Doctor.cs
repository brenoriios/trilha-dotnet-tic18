namespace TechMed.WebAPI;
public class Doctor : Person
{
    public required string Crm { get; set; }
    public required string Speciality { get; set; }
}
