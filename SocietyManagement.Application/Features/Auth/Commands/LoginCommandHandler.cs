using MediatR;
using Microsoft.AspNetCore.Identity;
using SocietyManagement.Application.Interfaces.Repositories;
using SocietyManagement.Application.Interfaces.Services;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Application.Features.Auth.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IUnitOfWork _uow;
    private readonly ITokenService _tokenService;
    private readonly UserManager<Member> _userManager;

    public LoginCommandHandler(IUnitOfWork uow, ITokenService tokenService, UserManager<Member> userManager)
    {
        _uow = uow;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var member = await _uow.Members.GetByEmailAsync(dto.EmailOrMobile) ??
                     await _uow.Members.GetByMobileAsync(dto.EmailOrMobile);
        if (member == null || !await _userManager.CheckPasswordAsync(member, dto.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        return _tokenService.GenerateToken(member);
    }
}
