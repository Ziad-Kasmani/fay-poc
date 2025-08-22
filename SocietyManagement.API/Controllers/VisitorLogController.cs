using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/flats/{flatId}/visitors")]
public class VisitorLogController : ControllerBase
{
    [HttpPost("check-in")]
    public IActionResult CheckIn(Guid flatId) => StatusCode(501);

    [HttpPut("{visitorLogId}/check-out")]
    public IActionResult CheckOut(Guid visitorLogId) => StatusCode(501);

    [HttpGet]
    public IActionResult Get(Guid flatId) => StatusCode(501);
}
