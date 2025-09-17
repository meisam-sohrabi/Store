using Microsoft.AspNetCore.Identity;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Command.Account;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Account
{
    public class AccountCommandRepository : IAccountCommandRepository
    {
        private readonly UserManager<CustomUserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountCommandRepository(UserManager<CustomUserEntity> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task DeleteUser(CustomUserEntity user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task UpdateUser(CustomUserEntity user)
        {
            await _userManager.UpdateAsync(user);
        }
        public async Task AddRole(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
        }
        public async Task AddRoleToUser(CustomUserEntity user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }
}
