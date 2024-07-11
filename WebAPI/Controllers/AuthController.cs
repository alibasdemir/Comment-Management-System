using Application.Features.Auth.Commands.Login;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var loginResponse = await _mediator.Send(loginCommand);
            return Ok(loginResponse);
        }
    }
}
