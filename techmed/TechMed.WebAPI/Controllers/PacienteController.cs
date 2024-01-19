using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteCollection _pacientes;
    public List<Paciente> Pacientes => _pacientes.GetAll().ToList();
    public PacienteController(IPacienteCollection pacientes)
    {
        _pacientes = pacientes;
    }

    [HttpGet("pacientes")]
    public IActionResult GetAll()
    {
        if (Pacientes.Count <= 0)
            return NoContent();

        return Ok(Pacientes);
    }

    [HttpGet("paciente/{id}")]
    public IActionResult GetById(int id)
    {
        var paciente = _pacientes.GetById(id);
        return Ok(paciente);
    }

    [HttpPost("paciente")]
    public IActionResult Post([FromBody] Paciente paciente)
    {
        Paciente _paciente = _pacientes.Create(paciente);
        return CreatedAtAction(nameof(GetById), new {id = paciente.PacienteId} , paciente);
    }

    [HttpPut("paciente/{id}")]
    public IActionResult Put(int id, [FromBody] Paciente paciente)
    {
        if (_pacientes.GetById(id) == null)
            return NoContent();

        _pacientes.Update(id, paciente);
        return Ok();
    }

    [HttpDelete("paciente/{id}")]
    public IActionResult Delete(int id)
    {
        if (_pacientes.GetById(id) == null)
            return NoContent();
        _pacientes.Delete(id);
        return Ok();
    }
}
