using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/societies/{societyId}/polls")]
public class PollsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(Guid societyId) => StatusCode(501);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Post(Guid societyId) => StatusCode(501);
}

[ApiController]
[Authorize]
[Route("api/polls")]
public class PollActionsController : ControllerBase
{
    [HttpPost("{pollId}/vote")]
    public IActionResult Vote(Guid pollId) => StatusCode(501);

    [HttpGet("{pollId}/results")]
    public IActionResult Results(Guid pollId) => StatusCode(501);
}
