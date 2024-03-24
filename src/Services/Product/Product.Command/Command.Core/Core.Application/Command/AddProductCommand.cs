using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Product;

namespace Core.Application.Command;

public class AddProductCommand: ProductDto, IRequest<IActionResult>
{
}
