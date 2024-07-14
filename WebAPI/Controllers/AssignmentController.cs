using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Delete;
using Application.Features.Assignments.Commands.Update;
using Application.Features.Assignments.Queries.GetById;
using Application.Features.Assignments.Queries.GetList;
using Application.Features.Assignments.Queries.GetListDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAssignmentCommand createAssignmentCommand)
        {
            CreateAssignmentResponse createAssignmentResponse = await _mediator.Send(createAssignmentCommand);
            return Ok(createAssignmentResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAssignmentCommand updateAssignmentCommand)
        {
            UpdateAssignmentResponse updateAssignmentResponse = await _mediator.Send(updateAssignmentCommand);
            return Ok(updateAssignmentResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteAssignmentCommand deleteAssignmentCommand = new() { Id = id };
            DeleteAssignmentResponse deleteAssignmentResponse = await _mediator.Send(deleteAssignmentCommand);
            return Ok(deleteAssignmentResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdAssignmentQuery getByIdAssignmentQuery = new() { Id = id };
            GetByIdAssignmentResponse getByIdAssignmentResponse = await _mediator.Send(getByIdAssignmentQuery);
            return Ok(getByIdAssignmentResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAssignmentQuery getListAssignmentQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListAssignmentResponse> getListAssignmentResponse = await _mediator.Send(getListAssignmentQuery);
            return Ok(getListAssignmentResponse);
        }

        [HttpPost("GetList/Dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
        {
            GetListDynamicAssignmentQuery getListDynamicAssignmentQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListDynamicAssignmentResponse> getListDynamicAssignmentResponse = await _mediator.Send(getListDynamicAssignmentQuery);
            return Ok(getListDynamicAssignmentResponse);
        }
    }
}
