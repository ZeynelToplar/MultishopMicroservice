using Multishop.CatalogApi.Dtos.ProductDtos;

namespace Multishop.CatalogApi.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetGetByIdProductAsync(string id);
    }
}
