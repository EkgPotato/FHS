using Microsoft.AspNetCore.Mvc;

namespace FHS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{

    [HttpGet]
    public IActionResult CheckHealth() => Ok();
}
