using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            UpdateUserResponse updateUserResponse = await _mediator.Send(updateUserCommand);
            return Ok(updateUserResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteUserCommand deleteUserCommand = new() { Id = id };
            DeleteUserResponse deleteUserResponse = await _mediator.Send(deleteUserCommand);
            return Ok(deleteUserResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdUserQuery getByIdUserQuery = new() { Id = id };
            GetByIdUserResponse getByIdUserResponse = await _mediator.Send(getByIdUserQuery);
            return Ok(getByIdUserResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListUserResponse> getListUserResponse = await _mediator.Send(getListUserQuery);
            return Ok(getListUserResponse);
        }
    }
}
