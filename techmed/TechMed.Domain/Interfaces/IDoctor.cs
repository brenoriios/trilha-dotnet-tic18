using Techmed.Domain.Entities;

namespace Techmed.Domain.Interfaces;
public interface IDoctor : IBaseRepository<Doctor>
{
    Task<Doctor> GetByCrm(string crm);
}
