using Microsoft.EntityFrameworkCore;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Infrastructure.Persistence;

namespace SocietyManagement.Infrastructure.Repositories;

public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
{
    public VendorRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Vendor>> GetBySocietyAsync(Guid societyId) =>
        await _dbSet.Where(v => v.SocietyId == societyId).ToListAsync();
}
