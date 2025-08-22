using MediatR;
using Microsoft.AspNetCore.Identity;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Domain.Entities;
using System.Linq;

namespace SocietyManagement.Application.Features.Members.Commands;

public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, MemberDto>
{
    private readonly UserManager<Member> _userManager;

    public RegisterMemberCommandHandler(UserManager<Member> userManager) => _userManager = userManager;

    public async Task<MemberDto> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var member = new Member
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            UserName = dto.Email,
            PhoneNumber = dto.MobileNumber,
            Role = dto.Role,
            SocietyId = dto.SocietyId
        };

        var result = await _userManager.CreateAsync(member, dto.Password);
        if (!result.Succeeded)
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

        return new MemberDto
        {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
            Email = member.Email!,
            MobileNumber = member.PhoneNumber ?? string.Empty,
            Role = member.Role
        };
    }
}
