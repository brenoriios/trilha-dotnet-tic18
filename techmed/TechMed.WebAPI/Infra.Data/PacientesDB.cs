using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra;
public class PacientesDB : IPacienteCollection
{
    private readonly List<Paciente> Pacientes = new List<Paciente>();
    private int _id = 0;
    public Paciente Create(Paciente paciente)
    {
        if (Pacientes.Count > 0)
        {
            _id = Pacientes.Max(paciente => paciente.PacienteId);
        }
        paciente.PacienteId = ++_id;
        Pacientes.Add(paciente);

        return paciente;
    }

    public ICollection<Paciente> GetAll()
    {
        return Pacientes;
    }

    public Paciente? GetById(int id)
    {
        return Pacientes.FirstOrDefault(paciente => paciente.PacienteId == id);
    }

    public void Update(int id, Paciente paciente)
    {
        var pacienteDB = Pacientes.FirstOrDefault(paciente => paciente.PacienteId == id);
        if (pacienteDB is not null)
        {
            pacienteDB.Nome = paciente.Nome;
        }
    }

    public void Delete(int id)
    {
        Pacientes.RemoveAll(paciente => paciente.PacienteId == id);
    }
}
