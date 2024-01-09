using Techmed.Model;

var db = new TechmedContext();

db.Doctors.Add(new Doctor(){
    Name = "Médico 1",
    Code = "COD001",
    Salary = 10000,
    Specialization = "Especialidade do Medico 1"
});

db.SaveChanges();

db.Doctors.ToList().ForEach(doctor => Console.WriteLine($"{doctor.Name} {doctor.Salary}"));
