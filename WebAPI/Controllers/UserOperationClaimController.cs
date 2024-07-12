using Application.Features.UserOperationClaims.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreateUserOperationClaimResponse createUserOperationClaimResponse = await _mediator.Send(createUserOperationClaimCommand);
            return Ok(createUserOperationClaimResponse);
        }
    }
}
