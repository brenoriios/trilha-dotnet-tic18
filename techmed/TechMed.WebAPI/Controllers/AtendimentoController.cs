using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoCollection _atendimentos;
    public List<Atendimento> Atendimentos => _atendimentos.GetAll().ToList();
    public AtendimentoController(IAtendimentoCollection atendimentos)
    {
        _atendimentos = atendimentos;
    }
    [HttpGet("atendimentos")]
    public IActionResult GetAll()
    {
        return Ok(_atendimentos.GetAll());
    }

    [HttpGet("atendimento/{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_atendimentos.GetById(id));
    }

    [HttpPost("atendimento")]
    public IActionResult Post([FromBody] Atendimento atendimento)
    {
        _atendimentos.Create(atendimento);
        return CreatedAtAction(nameof(GetAll), atendimento);
    }

    [HttpPut("atendimento/{id}")]
    public IActionResult Put(int id, [FromBody] Atendimento atendimento)
    {
        _atendimentos.Update(id, atendimento);
        return Ok();
    }

    [HttpDelete("atendimento/{id}")]
    public IActionResult Delete(int id)
    {
        if (_atendimentos.GetById(id) == null)
            return NoContent();
            
        _atendimentos.Delete(id);
        return Ok();
    }
}
