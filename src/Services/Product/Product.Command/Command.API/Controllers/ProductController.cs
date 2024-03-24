using Command.API.Controllers.Common;
using Core.Application.Command;
using Microsoft.AspNetCore.Mvc;

namespace Command.API.Controllers;

public class ProductController : BaseApiController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add(AddProductCommand command)
    {
        return await _mediatr.Send(command);
    }
}
