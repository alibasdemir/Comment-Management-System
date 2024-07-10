using Application.Features.Comments.Commands.Create;
using Application.Features.Comments.Commands.Delete;
using Application.Features.Comments.Commands.Update;
using Application.Features.Comments.Queries.GetById;
using Application.Features.Comments.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            GetByIdCommentQuery getByIdCommentQuery = new() { Id = id };
            GetByIdCommentResponse getByIdCommentResponse = await _mediator.Send(getByIdCommentQuery);
            return Ok(getByIdCommentResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentQuery getListCommentQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCommentResponse> getListCommentResponse = await _mediator.Send(getListCommentQuery);
            return Ok(getListCommentResponse);
        }
    }
}
