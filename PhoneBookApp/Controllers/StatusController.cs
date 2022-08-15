using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApp.Data;

namespace PhoneBookApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly PhoneBookContext context;

    public StatusController(PhoneBookContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult> GetStatus()
    {
        var canConnect = await context.Database.CanConnectAsync();
        if (canConnect)
        {
            return Ok(new
            {
                status = "OK"
            });
        }

        return StatusCode(500, "Unable to connect to DB");
    }
}
