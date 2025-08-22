using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/societies/{societyId}/expenses")]
public class ExpensesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(Guid societyId) => StatusCode(501);

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Post(Guid societyId) => StatusCode(501);

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Put(Guid societyId, Guid id) => StatusCode(501);

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Guid societyId, Guid id) => StatusCode(501);
}
