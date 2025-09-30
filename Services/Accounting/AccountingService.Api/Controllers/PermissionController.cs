using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AccountingService.ApplicationContract.DTO.Base;
using AccountingService.ApplicationContract.DTO.Permission;
using AccountingService.ApplicationContract.DTO.UserPermission;
using AccountingService.ApplicationContract.Interfaces.Permission;
using AccountingService.ApplicationContract.Interfaces.UserPermission;

namespace AccountingService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionAppService _permissionAppService;
        private readonly IUserPermissionAppService _userPermissionAppService;

        public PermissionController(IPermissionAppService permissionAppService, IUserPermissionAppService userPermissionAppService)
        {
            _permissionAppService = permissionAppService;
            _userPermissionAppService = userPermissionAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<PermissionDto>> Create([FromBody] PermissionDto PermissionDto)
        {
            return await _permissionAppService.CreatePermission(PermissionDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<PermissionDto>> Edit([FromRoute] int id, [FromBody] PermissionDto PermissionDto)
        {
            return await _permissionAppService.EditPermission(id, PermissionDto);
        }

        [HttpGet("GetAll")]
        [Authorize]
        public async Task<BaseResponseDto<List<PermissionDto>>> GetAll()
        {
            return await _permissionAppService.GetAllPermissions();
        }

        [HttpGet("GetAllUserPermissions")]
        [Authorize]
        public async Task<BaseResponseDto<List<ShowUserPermissionDto>>> GetAllUserPermissions([FromQuery] string userId)
        {
            return await _userPermissionAppService.GetAllUserPermissions(userId);
        }

        [HttpGet("GetAllNotAssignUserPermissions")]
        [Authorize]
        public async Task<BaseResponseDto<List<ShowUserPermissionDto>>> GetAllNotAssignUserPermissions([FromQuery] string userId)
        {
            return await _permissionAppService.GetAllUserNotAssignPermissions(userId);
        }

        [HttpPost("AssignPermission")]
        public async Task<BaseResponseDto<UserPermissionDto>> AssignPermission([FromBody] UserPermissionDto userPermissionDto)
        {
            return await _userPermissionAppService.AssignPermission(userPermissionDto);
        }

        [HttpPost("RevokePermission")]
        public async Task<BaseResponseDto<UserPermissionDto>> RevokePermission([FromBody] UserPermissionDto userPermissionDto)
        {
            return await _userPermissionAppService.RevokePermission(userPermissionDto);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<PermissionDto>> Delete([FromRoute] int id)
        {
            return await _permissionAppService.DeletePermission(id);
        }
    }
}
