using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Delete;
using Application.Features.Assignments.Commands.Update;
using Application.Features.Assignments.Queries.GetById;
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
    }
}
