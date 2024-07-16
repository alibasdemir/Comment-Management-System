using Application.Features.AuthWithVerifyCode.Commands.LoginWithCode;
using Application.Features.AuthWithVerifyCode.Commands.RegisterWithCode;
using Application.Features.AuthWithVerifyCode.Commands.VerifyEmail;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailTestController : BaseController
    {
        [HttpPost("register-with-code")]
        public async Task<IActionResult> Register([FromBody] RegisterWithCodeCommand registerWithCodeCommand)
        {
            RegisterWithCodeResponse response = await _mediator.Send(registerWithCodeCommand);
            return Ok(response);
        }

        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailCommand verifyEmailCommand)
        {
            VerifyEmailResponse response = await _mediator.Send(verifyEmailCommand);
            return Ok(response);
        }

        [HttpPut("login-with-code")]
        public async Task<IActionResult> Login([FromBody] LoginWithCodeCommand loginWithCodeCommand)
        {
            var loginResponse = await _mediator.Send(loginWithCodeCommand);
            return Ok(loginResponse);
        }
    }
}
