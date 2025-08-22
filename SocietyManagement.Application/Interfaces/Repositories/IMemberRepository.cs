using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Application.Interfaces.Repositories;

public interface IMemberRepository : IGenericRepository<Member>
{
    Task<Member?> GetByEmailAsync(string email);
    Task<Member?> GetByMobileAsync(string mobileNumber);
}
