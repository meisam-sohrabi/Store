using AccountingService.ApplicationContract.DTO.Base;
using AccountingService.ApplicationContract.DTO.UserPermission;


namespace AccountingService.ApplicationContract.Interfaces.UserPermission
{
    public interface IUserPermissionAppService
    {
        Task<BaseResponseDto<UserPermissionDto>> AssignPermission(UserPermissionDto userPermissionDto);
        Task<BaseResponseDto<UserPermissionDto>> RevokePermission(UserPermissionDto userPermissionDto);
        Task<BaseResponseDto<List<ShowUserPermissionDto>>> GetAllUserPermissions(string userId);
    }
}
