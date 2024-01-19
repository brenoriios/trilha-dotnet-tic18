using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra;
public class ExamesDB : IExameCollection
{
    private readonly List<Exame> Exames = new List<Exame>();
    private int _id = 0;
    public void Create(Exame exame)
    {
        if (Exames.Count <= 0)
        {
            _id = Exames.Max(exame => exame.ExameId);
        }
        exame.ExameId = ++_id;
        Exames.Add(exame);
    }

    public void Delete(int id)
    {
        Exames.RemoveAll(exame => exame.ExameId == id);
    }

    public ICollection<Exame> GetAll()
    {
        return Exames.ToArray();
    }

    public Exame? GetById(int id)
    {
        return Exames.FirstOrDefault(exame => exame.ExameId == id);
    }

    public void Update(int id, Exame exame)
    {
        var exameDB = Exames.FirstOrDefault(exame => exame.ExameId == id);
        if (exameDB is not null)
        {
            exameDB.DataHora = exame.DataHora;
        }
    }
}
