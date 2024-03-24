using Shared.Dtos.Product;

namespace Core.Application.Interfaces.RepositoryInterfaces;

public interface IProductCommandRepository
{
    Task<ProductDto> Create();
    Task<ProductDto> Update();
}
