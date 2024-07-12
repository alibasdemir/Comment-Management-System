using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Commands.Delete;
using Application.Features.UserOperationClaims.Commands.Update;
using Application.Features.UserOperationClaims.Queries.GetById;
using Application.Features.UserOperationClaims.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdateUserOperationClaimResponse updateUserOperationClaimResponse = await _mediator.Send(updateUserOperationClaimCommand);
            return Ok(updateUserOperationClaimResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteUserOperationClaimCommand deleteUserOperationClaimCommand = new() { Id = id };
            DeleteUserOperationClaimResponse deleteUserOperationClaimResponse = await _mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deleteUserOperationClaimResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery = new() { Id = id };
            GetByIdUserOperationClaimResponse getByIdUserOperationClaimResponse = await _mediator.Send(getByIdUserOperationClaimQuery);
            return Ok(getByIdUserOperationClaimResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListUserOperationClaimResponse> getListUserOperationClaimResponse = await _mediator.Send(getListUserOperationClaimQuery);
            return Ok(getListUserOperationClaimResponse);
        }
    }
}
