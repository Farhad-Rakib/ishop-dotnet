using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core.Application.Command;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, IActionResult>
{
    private readonly List<string> _validationMessage;
    private readonly ILogger<AddProductCommandHandler> _logger;
    public AddProductCommandHandler(ILogger<AddProductCommandHandler> logger)
    {
        _logger = logger;
    }
    public Task<IActionResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
