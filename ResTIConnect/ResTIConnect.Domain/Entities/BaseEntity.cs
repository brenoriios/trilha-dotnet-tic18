namespace ResTIConnect.Domain.Entities;
public class BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
