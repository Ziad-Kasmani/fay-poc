using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocietyManagement.Application.Interfaces.Services;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Member member)
    {
        var key = _configuration["JwtSettings:Key"]!;
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, member.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, member.Email!),
            new Claim(ClaimTypes.Role, member.Role.ToString())
        };

        var token = new JwtSecurityToken(issuer, audience, claims,
            expires: DateTime.UtcNow.AddHours(1), signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
