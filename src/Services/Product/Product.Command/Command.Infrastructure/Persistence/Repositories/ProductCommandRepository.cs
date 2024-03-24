using Core.Application.Interfaces.RepositoryInterfaces;
using Shared.Dtos.Product;

namespace Command.Infrastructure.Persistence.Repositories;

public class ProductCommandRepository : IProductCommandRepository
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
