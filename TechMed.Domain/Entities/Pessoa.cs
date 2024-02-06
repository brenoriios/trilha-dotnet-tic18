using TechMed.Domain.Entities.Common;

namespace TechMed.Domain.Entities;
public abstract class Pessoa : BaseEntity
{
    public required string Nome { get; set; }
    public required string Cpf { get; set; }
}
