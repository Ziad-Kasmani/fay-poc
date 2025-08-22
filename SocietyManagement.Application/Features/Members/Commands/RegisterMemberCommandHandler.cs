using MediatR;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace SocietyManagement.Application.Features.Members.Commands;

public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, MemberDto>
{
    private readonly IUnitOfWork _uow;

    public RegisterMemberCommandHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<MemberDto> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var member = new Member
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            MobileNumber = dto.MobileNumber,
            PasswordHash = HashPassword(dto.Password),
            Role = dto.Role,
            SocietyId = dto.SocietyId
        };

        await _uow.Members.AddAsync(member);
        await _uow.SaveChangesAsync();

        return new MemberDto
        {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            Email = member.Email,
            MobileNumber = member.MobileNumber,
            Role = member.Role
        };
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
