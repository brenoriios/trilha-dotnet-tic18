using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AppointmentController : ControllerBase
{
    private readonly IOptions<OpeningTime> _openingTime;
    public AppointmentController(IOptions<OpeningTime> openingTime)
    {
        _openingTime = openingTime;
    }

    [HttpGet("appointments")]
    public IActionResult GetAll()
    {
        var appointment = Enumerable.Range(1, 5).Select(index => new Appointment
        {
            AppointmentId = index,
            AppointmentDateTime = DateTime.Now,
            DoctorId = index,
            Doctor = new Doctor
            {
                DoctorId = index,
                Name = $"Doctor {index}",
                Crm = "12345",
                Salary = 12599
            }
        })
        .ToArray();
        return Ok(appointment);
    }

    [HttpGet("appointment/{id}")]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpPost("appointment")]
    public IActionResult Create()
    {
        if (_openingTime.Value.StartsAt > DateTime.Now.TimeOfDay || _openingTime.Value.EndsAt < DateTime.Now.TimeOfDay)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("appointment/{id}")]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete("appointment/{id}")]
    public IActionResult Delete()
    {
        return Ok();
    }
}
