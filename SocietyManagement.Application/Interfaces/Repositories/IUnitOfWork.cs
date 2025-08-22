using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IMemberRepository Members { get; }
    IVendorRepository Vendors { get; }
    IGenericRepository<Society> Societies { get; }
    Task<int> SaveChangesAsync();
}
