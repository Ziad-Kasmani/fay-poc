using MediatR;
using Microsoft.AspNetCore.Identity;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Application.Interfaces.Services;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Domain.Enums;
using System.Linq;

namespace SocietyManagement.Application.Features.Auth.Commands;

public class RegisterSocietyCommandHandler : IRequestHandler<RegisterSocietyCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IOtpService _otpService;
    private readonly UserManager<Member> _userManager;

    public RegisterSocietyCommandHandler(IUnitOfWork uow, IOtpService otpService, UserManager<Member> userManager)
    {
        _uow = uow;
        _otpService = otpService;
        _userManager = userManager;
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

        await _uow.Societies.AddAsync(society);
        await _uow.SaveChangesAsync();

        var member = new Member
        {
            Id = Guid.NewGuid(),
            FirstName = dto.AdminFirstName,
            LastName = dto.AdminLastName,
            Email = dto.Email,
            UserName = dto.Email,
            PhoneNumber = dto.MobileNumber,
            Role = MemberRole.Admin,
            SocietyId = society.Id
        };

        var result = await _userManager.CreateAsync(member, dto.Password);
        if (!result.Succeeded)
            throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

        await _otpService.GenerateOtpAsync(member.Email!);
        return society.Id;
    }
}
