using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class ExameController : ControllerBase
{
    private readonly IExameCollection _exames;
    public List<Exame> Exames => _exames.GetAll().ToList();
    public ExameController(IExameCollection exames)
    {
        _exames = exames;
    }
    [HttpGet("exames")]
    public IActionResult GetAll()
    {
        return Ok(_exames.GetAll());
    }

    [HttpGet("exame/{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(_exames.GetById(id));
    }

    [HttpPost("exame")]
    public IActionResult Post([FromBody] Exame exame)
    {
        _exames.Create(exame);
        return CreatedAtAction(nameof(GetAll), exame);
    }

    [HttpPut("exame/{id}")]
    public IActionResult Put(int id, [FromBody] Exame exame)
    {
        _exames.Update(id, exame);
        return Ok();
    }

    [HttpDelete("exame/{id}")]
    public IActionResult Delete(int id)
    {
        if (_exames.GetById(id) == null)
            return NoContent();
            
        _exames.Delete(id);
        return Ok();
    }
}
