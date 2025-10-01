using AccountingService.ApplicationContract.DTO.Account;
using AccountingService.ApplicationContract.DTO.Permission;
using AccountingService.ApplicationContract.DTO.Role;
using AccountingService.ApplicationContract.DTO.UserPermission;
using AccountingService.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AccountingService.Application.Services.Mapping
{
    public class MappingApplication : Profile
    {
        public MappingApplication()
        {
            CreateMap<CreateUserDto, CustomUserEntity>();
            CreateMap<CustomUserEntity, ShowUserInfoDto>();

            CreateMap<RoleDto, IdentityRole>();
            CreateMap<PermissionEntity, PermissionDto>();
            CreateMap<PermissionDto, PermissionEntity>();
            CreateMap<UserPermissionDto, UserPermissoinEntity>();

        }
    }
}
