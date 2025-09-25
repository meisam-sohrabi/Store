using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.UserPermission;


namespace ShopService.Application.Services.UserPermissoin
{
    public interface IUserPermissionAppService
    {
        Task<BaseResponseDto<UserPermissionDto>> AssignPermission(UserPermissionDto userPermissionDto);
        Task<BaseResponseDto<UserPermissionDto>> RevokePermission(UserPermissionDto userPermissionDto);
        Task<BaseResponseDto<List<ShowUserPermissionDto>>> GetAllUserPermissions(string userId);
    }
}
