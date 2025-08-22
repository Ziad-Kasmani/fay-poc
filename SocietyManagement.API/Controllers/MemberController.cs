using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Features.Members.Commands;
using SocietyManagement.Application.Features.Members.Queries;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Route("api/societies/{societyId}/members")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<MemberDto>> Register(Guid societyId, RegisterMemberDto dto)
    {
        dto.SocietyId = societyId;
        var member = await _mediator.Send(new RegisterMemberCommand(dto));
        return Ok(member);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembers(Guid societyId)
    {
        var members = await _mediator.Send(new GetMembersQuery(societyId));
        return Ok(members);
    }
}
