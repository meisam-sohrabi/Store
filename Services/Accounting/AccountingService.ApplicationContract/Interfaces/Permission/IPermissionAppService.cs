using AccountingService.ApplicationContract.DTO.Base;
using AccountingService.ApplicationContract.DTO.Permission;
using AccountingService.ApplicationContract.DTO.UserPermission;

namespace AccountingService.ApplicationContract.Interfaces.Permission
{
    public interface IPermissionAppService
    {
        Task<BaseResponseDto<PermissionDto>> CreatePermission(PermissionDto permissionDto);
        Task<BaseResponseDto<PermissionDto>> EditPermission(int id, PermissionDto permissionDto);
        Task<BaseResponseDto<PermissionDto>> DeletePermission(int id);
        Task<BaseResponseDto<List<PermissionDto>>> GetAllPermissions();
        Task<BaseResponseDto<List<ShowUserPermissionDto>>> GetAllUserNotAssignPermissions(string userId);

    }
}
