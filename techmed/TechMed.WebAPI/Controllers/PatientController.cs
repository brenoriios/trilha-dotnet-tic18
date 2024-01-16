using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("[controller]s")]
public class PatientController : ControllerBase
{
    private static readonly Patient[] patients = new[]
    {
        new Patient(){Id = 1, Name = "Paciente 1", Phone = "Telefone 1", Address = "Endereço 1"},
        new Patient(){Id = 2, Name = "Paciente 2", Phone = "Telefone 2", Address = "Endereço 2"},
        new Patient(){Id = 3, Name = "Paciente 3", Phone = "Telefone 3", Address = "Endereço 3"},
        new Patient(){Id = 4, Name = "Paciente 4", Phone = "Telefone 4", Address = "Endereço 4"},
        new Patient(){Id = 5, Name = "Paciente 5", Phone = "Telefone 5", Address = "Endereço 5"},
    };
    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPatient")]
    public IEnumerable<Patient> Get(){
        return patients;
    }
}
