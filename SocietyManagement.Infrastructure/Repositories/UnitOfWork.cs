using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Infrastructure.Persistence;

namespace SocietyManagement.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IMemberRepository Members { get; }
    public IVendorRepository Vendors { get; }
    public IGenericRepository<Society> Societies { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Members = new MemberRepository(context);
        Vendors = new VendorRepository(context);
        Societies = new GenericRepository<Society>(context);
    }

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
