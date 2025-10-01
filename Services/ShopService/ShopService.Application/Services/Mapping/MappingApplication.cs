using AutoMapper;
using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.DTO.Order;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductBrand;
using ShopService.ApplicationContract.DTO.ProductDetail;
using ShopService.Domain.Entities;

namespace ShopService.Application.Services.Mapping
{
    public class MappingApplication : Profile
    {
        public MappingApplication()
        {
            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<ProductRequestDto, ProductEntity>();
            CreateMap<ProductBrandDto, ProductBrandEntity>();
            CreateMap<ProductDetailRequestDto, ProductDetailEntity>();
            CreateMap<OrderDto, OrderEntity>();
        }
    }
}
