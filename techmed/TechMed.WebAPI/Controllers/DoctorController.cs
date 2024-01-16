using Microsoft.AspNetCore.Mvc;
namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class DoctorController : ControllerBase
{
    public static readonly Doctor[] doctors = new Doctor[] {
        new Doctor(){Id = 1, Name = "Médico 1", Crm = "12345", Speciality = "Especialidade 1"},
        new Doctor(){Id = 2, Name = "Médico 2", Crm = "22345", Speciality = "Especialidade 2"},
        new Doctor(){Id = 3, Name = "Médico 3", Crm = "32345", Speciality = "Especialidade 3"},
        new Doctor(){Id = 4, Name = "Médico 4", Crm = "42345", Speciality = "Especialidade 4"},
        new Doctor(){Id = 5, Name = "Médico 5", Crm = "52345", Speciality = "Especialidade 5"}
    };

    private readonly ILogger<DoctorController> _logger;

    public DoctorController(ILogger<DoctorController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDoctors")]
    public IEnumerable<Doctor> Get() {
        return doctors;
    }
}
