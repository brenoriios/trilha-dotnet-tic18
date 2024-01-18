namespace TechMed.WebAPI.Model;
public class Appointment{
    public int AppointmentId {get; set;}
    public DateTime AppointmentDateTime {get; set;}
    public int DoctorId {get; set;}
    public required Doctor Doctor {get; set;}
    // public int PacienteId {get; set;}
    // public required Paciente Paciente {get; set;}
    // public ICollection<Exame>? Exames {get;set;}
}
