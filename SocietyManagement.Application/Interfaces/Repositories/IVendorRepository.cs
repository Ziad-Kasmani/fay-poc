using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Application.Interfaces.Repositories;

public interface IVendorRepository : IGenericRepository<Vendor>
{
    Task<IEnumerable<Vendor>> GetBySocietyAsync(Guid societyId);
}
