using Application.Features.OperationClaims.Commands.Create;
using Application.Features.OperationClaims.Commands.Delete;
using Application.Features.OperationClaims.Commands.Update;
using Application.Features.OperationClaims.Queries.GetById;
using Application.Features.OperationClaims.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreateOperationClaimResponse createOperationClaimResponse = await _mediator.Send(createOperationClaimCommand);
            return Ok(createOperationClaimResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdateOperationClaimResponse updateOperationClaimResponse = await _mediator.Send(updateOperationClaimCommand);
            return Ok(updateOperationClaimResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteOperationClaimCommand deleteOperationClaimCommand = new() { Id = id };
            DeleteOperationClaimResponse deleteOperationClaimResponse = await _mediator.Send(deleteOperationClaimCommand);
            return Ok(deleteOperationClaimResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdOperationClaimQuery getByIdOperationClaimQuery = new() { Id = id };
            GetByIdOperationClaimResponse getByIdOperationClaimResponse = await _mediator.Send(getByIdOperationClaimQuery);
            return Ok(getByIdOperationClaimResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListOperationClaimResponse> getListOperationClaimResponse = await _mediator.Send(getListOperationClaimQuery);
            return Ok(getListOperationClaimResponse);
        }
    }
}
