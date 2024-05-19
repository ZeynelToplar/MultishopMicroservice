using Multishop.CatalogApi.Dtos.CategoryDtos;

namespace Multishop.CatalogApi.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryId> GetGetByIdCategoryAsync(string id);
    }
}
