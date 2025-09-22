using AutoMapper;
using ShopService.Domain.Entities;
using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductBrand;
using ShopService.ApplicationContract.DTO.ProductDetail;
using ShopService.ApplicationContract.DTO.Permission;
using ShopService.ApplicationContract.DTO.Role;
using Microsoft.AspNetCore.Identity;

namespace ShopService.Application.Services.Mapping
{
    public class MappingApplication : Profile
    {
        public MappingApplication()
        {
            CreateMap<CategoryDto, CategoryEntity>();
            CreateMap<ProductRequestDto, ProductEntity>();
            CreateMap<CustomUserEntity, CreateUserDto>();
            CreateMap<CustomUserEntity, ShowUserInfoDto >();
            CreateMap<ProductBrandDto, ProductBrandEntity >();
            CreateMap<ProductDetailRequestDto, ProductDetailEntity >();
            CreateMap<PermissionDto, PermissionEntity >();
            CreateMap<PermissionEntity, PermissionDto>();
            CreateMap<RoleDto, IdentityRole>();
        }
    }
}
