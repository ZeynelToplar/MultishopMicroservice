using AutoMapper;
using Multishop.CatalogApi.Dtos.CategoryDtos;
using Multishop.CatalogApi.Dtos.ProductDetailDtos;
using Multishop.CatalogApi.Dtos.ProductDtos;
using Multishop.CatalogApi.Dtos.ProductImageDtos;
using Multishop.CatalogApi.Entities;

namespace Multishop.CatalogApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            //Mapping for category class
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryId>().ReverseMap();

            //Mapping for product class
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();

            //Mapping for productdetail class
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            //Mapping for productimage class
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
        }
    }
}
