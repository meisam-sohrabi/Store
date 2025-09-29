using GatewayService.Domain.Entities;
using GatewayService.InfrastructureContract.Interfaces.Query.Role;
using Microsoft.AspNetCore.Identity;

namespace GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Query.Role
{
    public class RoleQueryRepository : IRoleQueryRepository
    {
        private readonly UserManager<CustomUserEntity> _userManager;

        public RoleQueryRepository(UserManager<CustomUserEntity> userManager)
        {
            _userManager = userManager;

        }
        public async Task<IList<string>> Roles(CustomUserEntity user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
