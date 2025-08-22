using MediatR;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Application.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace SocietyManagement.Application.Features.Auth.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;

    public LoginCommandHandler(IUnitOfWork uow, ITokenService tokenService)
    {
        _uow = uow;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var member = await _uow.Members.GetByEmailAsync(dto.EmailOrMobile) ??
                     await _uow.Members.GetByMobileAsync(dto.EmailOrMobile);
        if (member == null || member.PasswordHash != HashPassword(dto.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        return _tokenService.GenerateToken(member);
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
