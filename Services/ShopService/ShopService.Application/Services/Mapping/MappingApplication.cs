using AutoMapper;
using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.DTO.Order;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductBrand;
using ShopService.ApplicationContract.DTO.ProductDetail;
using ShopService.ApplicationContract.DTO.ProductInventory;
using ShopService.ApplicationContract.DTO.ProductPrice;
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
            CreateMap<ProductInventoryRequestDto, ProductInventoryEntity>();
            CreateMap<ProductPriceRequestDto, ProductPriceEntity>();
            CreateMap<OrderRequestDto, OrderEntity>();
        }
    }
}
