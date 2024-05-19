using Multishop.CatalogApi.Dtos.ProductImageDtos;

namespace Multishop.CatalogApi.Services.ProductImageImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetGetByIdProductImageAsync(string id);
    }
}
