using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocietyManagement.API.Controllers;

[ApiController]
[Authorize]
[Route("api/flats/{flatId}/bills")]
public class BillingController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(Guid flatId) => StatusCode(501);

    [HttpGet]
    public IActionResult Get(Guid flatId) => StatusCode(501);

    [HttpPut("{billId}/mark-as-paid")]
    public IActionResult MarkAsPaid(Guid billId) => StatusCode(501);
}
