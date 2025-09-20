using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MC.API.Controllers.Approval
{
    [ApiController]                       // tells ASP.NET Core this is an API controller
    [Route("api/[controller]")]           // sets route prefix based on controller name
    public class AAATestController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("ping")]                 // GET /api/AAATest/ping
        public IActionResult Ping() => Ok("pong");
    }
}
