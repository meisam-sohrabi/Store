using Microsoft.AspNetCore.Identity;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Auth;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Auth
{
    public class AuthQueryRepository : IAuthQueryRepository
    {
        private readonly UserManager<CustomUserEntity> _userManager;

        public AuthQueryRepository(UserManager<CustomUserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> CheckPassword(CustomUserEntity user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
