using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Permission;

namespace ShopService.ApplicationContract.Interfaces.Permission
{
    public interface IPermissionAppService
    {
        Task<BaseResponseDto<PermissionDto>> CreatePermission(PermissionDto permissionDto);
        Task<BaseResponseDto<PermissionDto>> EditPermission(int id,PermissionDto permissionDto);
        Task<BaseResponseDto<PermissionDto>> DeletePermission(int id);
        Task<BaseResponseDto<List<PermissionDto>>> GetAllPermissions();
    }
}
