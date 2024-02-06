using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI.InputModels;

namespace OrdemServico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PrestadorDeServicoController : ControllerBase
{
    [HttpGet("prestadores-de-servico")]
    public IActionResult Get()
    {
        return NoContent();
    }
    [HttpGet("prestador-de-servico/{id}")]
    public IActionResult GetById(int id)
    {
        return NoContent();
    }
    [HttpPost("prestador-de-servico")]
    public IActionResult Post([FromBody] NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        return NoContent();
    }
    [HttpPut("prestador-de-servico/{id}")]
    public IActionResult Put(int id, [FromBody] NewPrestadorDeServicoInputModel prestadorDeServico)
    {
        return NoContent();
    }
    [HttpDelete("prestador-de-servico/{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
