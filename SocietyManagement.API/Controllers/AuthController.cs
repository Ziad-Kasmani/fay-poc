using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Features.Auth.Commands;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) => _mediator = mediator;

    [HttpPost("register-society")]
    public async Task<IActionResult> RegisterSociety(RegisterSocietyDto dto)
    {
        var id = await _mediator.Send(new RegisterSocietyCommand(dto));
        return Ok(new { SocietyId = id });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await _mediator.Send(new LoginCommand(dto));
        return Ok(new { Token = token });
    }

    [HttpPost("verify-otp")]
    public async Task<IActionResult> VerifyOtp(VerifyOtpDto dto)
    {
        var result = await _mediator.Send(new VerifyOtpCommand(dto));
        return result ? Ok() : BadRequest();
    }
}
