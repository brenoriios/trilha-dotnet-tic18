using Microsoft.AspNetCore.Mvc;
using Techmed.Infrastructure.TechmedDbContext;
using Techmed.Domain.Entities;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v0.1/[controller]s")]
public class DoctorController : ControllerBase
{
    private static readonly TechmedDbContext db = new TechmedDbContext();

    private readonly ILogger<DoctorController> _logger;

    public DoctorController(ILogger<DoctorController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDoctors")]
    public IActionResult Get() {
        return Ok(db.Doctors.ToArray());
    }

    [HttpPost(Name = "CreateDoctor")]
    public IActionResult Create(string _name, string _cpf, string _crm, string _specialization, float _salary){
        db.Doctors.Add(new Doctor() {
            Name = _name,
            Cpf = _cpf,
            Crm = _crm,
            Specialization = _specialization,
            Salary = _salary
        });
        db.SaveChanges();

        return Ok();
    }

    [HttpPut(Name = "UpdateDoctor")]
    public IActionResult Update(int id, string _name, string _cpf, string _crm, string _specialization, float _salary){
        var Doctor = db.Doctors.FirstOrDefault(d => d.Id == id);
        if(Doctor == null) {
            return NoContent();
        }

        Doctor.Name = _name;
        Doctor.Cpf = _cpf;
        Doctor.Crm = _crm;
        Doctor.Specialization = _specialization;
        Doctor.Salary = _salary;

        db.Doctors.Update(Doctor);
        db.SaveChanges();

        return Accepted();
    }

    [HttpDelete(Name = "DeleteDoctor")]
    public IActionResult Delete(int id) {
        var Doctor = db.Doctors.FirstOrDefault(d => d.Id == id);
        if(Doctor == null) {
            return NoContent();
        }
        db.Doctors.Remove(Doctor);
        db.SaveChanges();

        return Ok();
    }
}
