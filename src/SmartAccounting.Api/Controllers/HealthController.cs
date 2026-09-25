using Microsoft.AspNetCore.Mvc;

namespace SmartAccounting.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Health()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "SmartAccounting.Api"
        });
    }
}
