using Application.Features.Users.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
            CreateUserResponse createUserResponse = await _mediator.Send(createUserCommand);
            return Ok(createUserResponse);
        }
    }
}
