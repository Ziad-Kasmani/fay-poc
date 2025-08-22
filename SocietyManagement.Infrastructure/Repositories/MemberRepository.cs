using Microsoft.EntityFrameworkCore;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Infrastructure.Persistence;

namespace SocietyManagement.Infrastructure.Repositories;

public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    public MemberRepository(ApplicationDbContext context) : base(context) { }

    public Task<Member?> GetByEmailAsync(string email) =>
        _dbSet.FirstOrDefaultAsync(m => m.Email == email);

    public Task<Member?> GetByMobileAsync(string mobileNumber) =>
        _dbSet.FirstOrDefaultAsync(m => m.MobileNumber == mobileNumber);
}
