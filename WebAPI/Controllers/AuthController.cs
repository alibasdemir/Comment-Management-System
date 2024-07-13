using Application.Features.Auth.Commands.ChangePassword;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisterResponse registerResponse = await _mediator.Send(registerCommand);
            return Ok(registerResponse);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changePasswordCommand)
        {
            ChangePasswordResponse changePasswordResponse = await _mediator.Send(changePasswordCommand);
            return Ok(changePasswordResponse);
        }
    }
}
