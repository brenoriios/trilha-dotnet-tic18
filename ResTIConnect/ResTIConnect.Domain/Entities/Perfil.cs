namespace ResTIConnect.Domain.Entities;
public class Perfil : BaseEntity
{
    public int PerfilId { get; set; }
    public required string Descricao { get; set; }
    public required string Permissoes { get; set; }
}
