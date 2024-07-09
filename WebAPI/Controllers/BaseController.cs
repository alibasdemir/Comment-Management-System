using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator _mediator => HttpContext.RequestServices.GetService<IMediator>() ?? throw new InvalidOperationException("IMediator can't be resolved.");
    }
}
