using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Command.API.Controllers.Common;

[ApiController]
[Route("api/v{version:apiVersion}/")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator _mediatr => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
