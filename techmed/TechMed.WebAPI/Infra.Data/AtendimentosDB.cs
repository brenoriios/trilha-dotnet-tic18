using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra;
public class AtendimentosDB : IAtendimentoCollection
{
    private readonly List<Atendimento> Atendimentos = new List<Atendimento>();
    private int _id = 0;
    public void Create(Atendimento atendimento)
    {
        if (Atendimentos.Count <= 0)
        {
            _id = Atendimentos.Max(atendimento => atendimento.AtendimentoId);
        }
        atendimento.AtendimentoId = ++_id;
        Atendimentos.Add(atendimento);
    }

    public void Delete(int id)
    {
        Atendimentos.RemoveAll(atendimento => atendimento.AtendimentoId == id);
    }

    public ICollection<Atendimento> GetAll()
    {
        return Atendimentos.ToArray();
    }

    public Atendimento? GetById(int id)
    {
        return Atendimentos.FirstOrDefault(atendimento => atendimento.AtendimentoId == id);
    }

    public void Update(int id, Atendimento atendimento)
    {
        var atendimentoDB = Atendimentos.FirstOrDefault(atendimento => atendimento.AtendimentoId == id);
        if (atendimentoDB is not null)
        {
            atendimentoDB.DataHora = atendimento.DataHora;
            atendimentoDB.MedicoId = atendimento.MedicoId;
            atendimentoDB.PacienteId = atendimento.PacienteId;
        }
    }
}
