using System.Globalization;
using Techmed.Domain.Entities;
using Techmed.Infrastructure.TechmedDbContext;

CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-br");

var db = new TechmedDbContext();

db.Exams.RemoveRange(db.Exams);
db.Appointments.RemoveRange(db.Appointments);
db.Doctors.RemoveRange(db.Doctors);
db.Patients.RemoveRange(db.Patients);

// Medico 1
var doctor = new Doctor(){
    Name = "Médico 1",
    Cpf = "123.456.789-01",
    Crm = "123456",
    Specialization = "Alguma",
    Salary = 12324.99f
};
db.Doctors.Add(doctor);

// Paciente 1
var patient = new Patient(){
    Name = "Paciente 1",
    Cpf = "123.456.789-02",
    Address = "Rua Tal, N° Tal - Bairro Tal",
    Phone = "91234-5678"
};
db.Patients.Add(patient);

db.SaveChanges();

// Atendimento 1 : Medico 1, Paciente 1
var appointment1 = new Appointment(){
    Date = DateTime.Now + TimeSpan.FromDays(-1),
    Doctor = doctor,
    Patient = patient
};

// Atendimento 2 : Medico 1, Paciente 1
var appointment2 = new Appointment(){
    Date = DateTime.Now + TimeSpan.FromDays(-2),
    Doctor = doctor,
    Patient = patient
};

// Atendimento 3 : Medico 1, Paciente 1
var appointment3 = new Appointment(){
    Date = DateTime.Now + TimeSpan.FromDays(-3),
    Doctor = doctor,
    Patient = patient
};

db.AddRange(appointment1, appointment2, appointment3);
db.SaveChanges();

var exam1 = new Exam(){
    Name = "Exame 1",
    Place = "Hospital",
    Price = 150,
    Date = DateTime.Now + TimeSpan.FromDays(-1),
    Appointments = new List<Appointment>{appointment1, appointment2}
};

var exam2 = new Exam(){
    Name = "Exame 2",
    Place = "Clinica",
    Price = 150,
    Date = DateTime.Now + TimeSpan.FromDays(-2),
    Appointments = new List<Appointment>{appointment1, appointment3}
};

var exam3 = new Exam(){
    Name = "Exame 3",
    Place = "Consultório",
    Price = 150,
    Date = DateTime.Now + TimeSpan.FromDays(-3),
    Appointments = new List<Appointment>{appointment2, appointment3}
};

db.Exams.AddRange(exam1, exam2, exam3);

db.SaveChanges();

Console.WriteLine($"Finalizando o programa");

var selectedPatient = db.Patients.Where(p => p.Name == "Paciente 1").FirstOrDefault();

selectedPatient.Appointments.ToList().ForEach(a => a.Exams.ToList().ForEach(e => Console.WriteLine($"Exame: {e.Place} - {e.Date}")));

var atendimentoHospital = db.Appointments.Where(a => a.Exams.Any(e => e.Place == "Hospital")).FirstOrDefault();
