using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.CatalogApi.Dtos.ProductDetailDtos;
using Multishop.CatalogApi.Services.ProductDetailDetailServices;
using Multishop.CatalogApi.Services.ProductDetailServices;

namespace Multishop.CatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailDetailsController : ControllerBase
    {
        private readonly IProductDetailService _ProductDetailService;
        public ProductDetailDetailsController(IProductDetailService ProductDetailService)
        {
            _ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await _ProductDetailService.GetGetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Urun detayi basariyla eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("Urun detayi basariyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _ProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Urun detayi basariyla guncellendi");
        }
    }
}
