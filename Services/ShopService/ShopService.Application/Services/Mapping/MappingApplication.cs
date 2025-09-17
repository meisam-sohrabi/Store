using AutoMapper;
using ShopService.Domain.Entities;
using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.DTO.Product;

namespace ShopService.Application.Services.Mapping
{
    public class MappingApplication : Profile
    {
        public MappingApplication()
        {
            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<ProductDto, ProductEntity>();
            CreateMap<CustomUserEntity, CreateUserDto>();
            CreateMap<CustomUserEntity, ShowUserInfoDto >();
        }
    }
}
