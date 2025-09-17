using AutoMapper;
using Second.ApplicationContract.DTO.Account;
using Second.ApplicationContract.DTO.Category;
using Second.ApplicationContract.DTO.Product;
using Second.Domain.Entities;

namespace Second.ApplicationContract.Mapping
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
