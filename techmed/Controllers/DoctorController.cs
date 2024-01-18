using Microsoft.AspNetCore.Mvc;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("api/v0.1/")]
public class DoctorController : ControllerBase
{
    private static int _id = 0;
    private readonly ICollection<Doctor> _doctors;
    public DoctorController(DoctorCollection doctors)
    {
        _doctors = doctors.Doctors;
    }

    [HttpGet("doctors", Name = "GetDoctors")]
    public IActionResult GetAll()
    {
        return Ok(_doctors);
    }

    [HttpGet("doctor/{id}", Name = "GetDoctorById")]
    public IActionResult Get(int id)
    {
        var doctor = _doctors.FirstOrDefault(doctor => doctor.DoctorId == id);

        if(doctor == null){
            return NotFound();
        }

        return Ok(doctor);
    }

    [HttpPost("doctor", Name = "CreateDoctor")]
    public IActionResult Create(string _name, string _cpf, string _crm, string _specialization, float _salary)
    {
        var doctor = new Doctor()
        {
            DoctorId = _id++,
            Name = _name,
            Crm = _crm,
            Specialization = _specialization,
            Salary = _salary
        };
        _doctors.Add(doctor);

        return Accepted(doctor);
    }

    [HttpPut("doctor/{id}", Name = "UpdateDoctor")]
    public IActionResult Update(int id, string _name, string _cpf, string _crm, string _specialization, float _salary)
    {
        var doctor = _doctors.FirstOrDefault(doctor => doctor.DoctorId == id);

        if(doctor == null){
            return NotFound();
        }

        doctor.Name = _name;
        doctor.Crm = _crm;
        doctor.Specialization = _specialization;
        doctor.Salary = _salary;

        return Ok(doctor);
    }

    [HttpDelete("doctor/{id}", Name = "DeleteDoctor")]
    public IActionResult Delete(int id)
    {
        var doctor = _doctors.FirstOrDefault(doctor => doctor.DoctorId == id);

        if(doctor == null){
            return NotFound();
        }

        _doctors.Remove(doctor);

        return Ok();
    }
}
