namespace Techmed.Domain.Entities;
public abstract class Person : BaseEntity
{
    public required string Name { get; set;}
    public required string Cpf { get; set; }
}
