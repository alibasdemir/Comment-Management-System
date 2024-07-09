using Application.Features.Assignments.Commands.Create;
using Application.Features.Assignments.Commands.Update;
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
    }
}
