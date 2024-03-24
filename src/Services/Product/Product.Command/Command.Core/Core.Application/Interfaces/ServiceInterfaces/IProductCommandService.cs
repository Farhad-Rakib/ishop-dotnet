using Shared.Dtos.Product;

namespace Core.Application.Interfaces.ServiceInterfaces;

public interface IProductCommandService
{
    Task<ProductDto> Create();
    Task<ProductDto> Update();
}
