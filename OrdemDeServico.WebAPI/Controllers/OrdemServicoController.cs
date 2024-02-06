using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI;
using OrdemDeServico.WebAPI.InputModels;

namespace OrdemServico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class OrdemServicoController : ControllerBase
{
    [HttpGet("ordens-de-servico")]
    public IActionResult Get()
    {
        return NoContent();
    }
    [HttpGet("ordem-de-servico/{id}")]
    public IActionResult GetById(int id)
    {
        return NoContent();
    }
    [HttpPost("ordem-de-servico")]
    public IActionResult Post([FromBody] NewOrdemServicoInputModel ordemDeServico)
    {
        return NoContent();
    }
    [HttpPut("ordem-de-servico/{id}")]
    public IActionResult Put(int id, [FromBody] NewOrdemServicoInputModel ordemDeServico)
    {
        return NoContent();
    }
    [HttpDelete("ordem-de-servico/{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
