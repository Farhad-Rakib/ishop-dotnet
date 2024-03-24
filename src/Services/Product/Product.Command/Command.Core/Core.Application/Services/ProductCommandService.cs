using Core.Application.Interfaces.ServiceInterfaces;
using Shared.Dtos.Product;

namespace Core.Application.Services;

public class ProductCommandService : IProductCommandService
{
    public Task<ProductDto> Create()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> Update()
    {
        throw new NotImplementedException();
    }
}
