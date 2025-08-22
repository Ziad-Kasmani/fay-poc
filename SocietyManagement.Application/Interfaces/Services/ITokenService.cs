using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(Member member);
}
