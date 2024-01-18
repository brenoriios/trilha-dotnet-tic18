using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v0.1/")]
public class DoctorController : ControllerBase
{
    private readonly ILogger<DoctorController> _logger;

    public DoctorController(ILogger<DoctorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("doctors", Name = "GetDoctors")]
    public IActionResult GetAll() {
        return Ok();
    }

    [HttpGet("doctor/{id}", Name = "GetDoctorById")]
    public IActionResult Get(int id) {
        return Ok();
    }

    [HttpPost("doctor", Name = "CreateDoctor")]
    public IActionResult Create(string _name, string _cpf, string _crm, string _specialization, float _salary){
        return Ok();
    }

    [HttpPut("doctor/{id}", Name = "UpdateDoctor")]
    public IActionResult Update(int id, string _name, string _cpf, string _crm, string _specialization, float _salary){
        return Accepted();
    }

    [HttpDelete("doctor/{id}", Name = "DeleteDoctor")]
    public IActionResult Delete(int id) {
        return Ok();
    }
}
