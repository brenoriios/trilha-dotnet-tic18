using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.WebAPI.InputModels;

namespace OrdemServico.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class PagamentoController : ControllerBase
{
    [HttpGet("pagamentos")]
    public IActionResult Get()
    {
        return NoContent();
    }
    [HttpGet("pagamento/{id}")]
    public IActionResult GetById(int id)
    {
        return NoContent();
    }
    [HttpPost("pagamento")]
    public IActionResult Post([FromBody] NewPagamentoInputModel pagamento)
    {
        return NoContent();
    }
    [HttpPut("pagamento/{id}")]
    public IActionResult Put(int id, [FromBody] NewPagamentoInputModel pagamento)
    {
        return NoContent();
    }
    [HttpDelete("pagamento/{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
