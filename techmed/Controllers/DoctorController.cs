using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v0.1/")]
public class DoctorController : ControllerBase
{
    private readonly ICollection<Doctor> _doctors;
    public DoctorController(DoctorCollection doctors){
        _doctors = doctors.Doctors;
    }

    [HttpGet("doctors", Name = "GetDoctors")]
    public IActionResult GetAll() {
        return Ok(_doctors);
    }

    [HttpGet("doctor/{id}", Name = "GetDoctorById")]
    public IActionResult Get(int id) {
        return Ok(_doctors.FirstOrDefault(doctor => doctor.DoctorId == id));
    }

    [HttpPost("doctor", Name = "CreateDoctor")]
    public IActionResult Create(string _name, string _cpf, string _crm, string _specialization, float _salary){
        var doctor = new Doctor(){
            Name = _name,
            Crm = _crm,
            Specialization = _specialization,
            Salary = _salary
        };
        _doctors.Add(doctor);
        return Accepted(doctor);
    }

    [HttpPut("doctor/{id}", Name = "UpdateDoctor")]
    public IActionResult Update(int id, string _name, string _cpf, string _crm, string _specialization, float _salary){
        return Ok();
    }

    [HttpDelete("doctor/{id}", Name = "DeleteDoctor")]
    public IActionResult Delete(int id) {
        return Ok();
    }
}
