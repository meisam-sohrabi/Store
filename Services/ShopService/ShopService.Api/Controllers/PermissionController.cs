using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Permission;
using ShopService.ApplicationContract.Interfaces.Permission;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionAppService _permissionAppService;

        public PermissionController(IPermissionAppService permissionAppService)
        {
            _permissionAppService = permissionAppService;
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

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<PermissionDto>> Delete([FromRoute] int id)
        {
            return await _permissionAppService.DeletePermission(id);
        }
    }
}
