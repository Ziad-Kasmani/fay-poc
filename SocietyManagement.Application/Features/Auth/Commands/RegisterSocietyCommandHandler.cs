using MediatR;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Application.Interfaces.Services;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace SocietyManagement.Application.Features.Auth.Commands;

public class RegisterSocietyCommandHandler : IRequestHandler<RegisterSocietyCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IOtpService _otpService;

    public RegisterSocietyCommandHandler(IUnitOfWork uow, IOtpService otpService)
    {
        _uow = uow;
        _otpService = otpService;
    }

    public async Task<Guid> Handle(RegisterSocietyCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var society = new Society
        {
            Id = Guid.NewGuid(),
            Name = dto.SocietyName,
            Address = dto.Address,
            RegistrationNumber = dto.RegistrationNumber,
            CreatedAt = DateTime.UtcNow
        };

        var member = new Member
        {
            Id = Guid.NewGuid(),
            FirstName = dto.AdminFirstName,
            LastName = dto.AdminLastName,
            Email = dto.Email,
            MobileNumber = dto.MobileNumber,
            PasswordHash = HashPassword(dto.Password),
            Role = MemberRole.Admin,
            SocietyId = society.Id,
            IsEmailVerified = false,
            IsMobileVerified = false
        };

        await _uow.Societies.AddAsync(society);
        await _uow.Members.AddAsync(member);
        await _uow.SaveChangesAsync();

        await _otpService.GenerateOtpAsync(member.Email);
        return society.Id;
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
