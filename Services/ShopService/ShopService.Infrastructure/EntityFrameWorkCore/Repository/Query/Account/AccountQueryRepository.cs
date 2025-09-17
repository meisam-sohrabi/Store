using Microsoft.AspNetCore.Identity;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Account;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Account
{
    public class AccountQueryRepository : IAccountQueryRepository
    {
        private readonly UserManager<CustomUserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountQueryRepository(UserManager<CustomUserEntity> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public  IQueryable<CustomUserEntity> GetQueryableUsers()
        {
            return  _userManager.Users.AsQueryable();
        }

        public async Task<CustomUserEntity> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<CustomUserEntity> GetUserByUsername(string username)
        {
            return await _userManager.FindByEmailAsync(username);
        }


        public async Task<bool> RoleExist(string role)
        {
           return await _roleManager.RoleExistsAsync(role);
        }

        public async Task<IList<string>> Roles(CustomUserEntity user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
