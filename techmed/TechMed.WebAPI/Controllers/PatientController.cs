using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Techmed.Domain.Entities;
using Techmed.Infrastructure.TechmedDbContext;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v0.1/[controller]s")]
public class PatientController : ControllerBase
{
    private static readonly TechmedDbContext db = new TechmedDbContext();
    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPatients")]
    public IActionResult GetAll(){
        return Ok(db.Patients.ToArray());
    }

    [HttpGet("{id}", Name = "GetPatientById")]
    public IActionResult Get(int id) {
        var patient = db.Patients.FirstOrDefault(d => d.Id == id);
        if(patient == null) {
            return NoContent();
        }
        return Ok(patient);
    }

    [HttpPost(Name = "CreatePatient")]
    public IActionResult Create(string _name, string _cpf, string _address, string _phone){
        db.Patients.Add(new Patient() {
            Name = _name,
            Cpf = _cpf,
            Address = _address,
            Phone = _phone
        });
        db.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}", Name = "UpdatePatient")]
    public IActionResult Update(int id, string _name, string _cpf, string _address, string _phone){
        var patient = db.Patients.FirstOrDefault(p => p.Id == id);
        if(patient == null) {
            return NoContent();
        }

        patient.Name = _name;
        patient.Cpf = _cpf;
        patient.Address = _address;
        patient.Phone = _phone;

        db.Patients.Update(patient);
        db.SaveChanges();

        return Accepted();
    }

    [HttpDelete("{id}", Name = "DeletePatient")]
    public IActionResult Delete(int id) {
        var patient = db.Patients.FirstOrDefault(p => p.Id == id);
        if(patient == null) {
            return NoContent();
        }
        db.Patients.Remove(patient);
        db.SaveChanges();

        return Ok();
    }
}
