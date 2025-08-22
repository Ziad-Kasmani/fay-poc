using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocietyManagement.Application.DTOs;
using SocietyManagement.Application.Features.Vendors.Commands;
using SocietyManagement.Application.Features.Vendors.Queries;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/societies/{societyId}/vendors")]
public class VendorController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendorController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IEnumerable<VendorDto>> Get(Guid societyId)
        => await _mediator.Send(new GetVendorsQuery(societyId));

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<VendorDto>> Post(Guid societyId, VendorDto dto)
    {
        dto.SocietyId = societyId;
        var vendor = await _mediator.Send(new CreateVendorCommand(dto));
        return Ok(vendor);
    }
}
