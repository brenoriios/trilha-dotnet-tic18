using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v0.1/")]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }

    [HttpGet("patients", Name = "GetPatients")]
    public IActionResult GetAll(){
        return Ok();
    }

    [HttpGet("patient/{id}", Name = "GetPatientById")]
    public IActionResult Get(int id) {
        return Ok();
    }

    [HttpPost("patient", Name = "CreatePatient")]
    public IActionResult Create(string _name, string _cpf, string _address, string _phone){
        return Ok();
    }

    [HttpPut("patient/{id}", Name = "UpdatePatient")]
    public IActionResult Update(int id, string _name, string _cpf, string _address, string _phone){
        return Accepted();
    }

    [HttpDelete("patient/{id}", Name = "DeletePatient")]
    public IActionResult Delete(int id) {
        return Ok();
    }
}
