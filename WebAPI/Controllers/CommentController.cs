using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCommentCommand createCommentCommand)
        {
            CreateCommentResponse createCommentResponse = await _mediator.Send(createCommentCommand);
            return Ok(createCommentResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            UpdateCommentResponse updateCommentResponse = await _mediator.Send(updateCommentCommand);
            return Ok(updateCommentResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            DeleteCommentCommand deleteCommentCommand = new() { Id = id };
            DeleteCommentResponse deleteCommentResponse = await _mediator.Send(deleteCommentCommand);
            return Ok(deleteCommentResponse);
        }
    }
}
