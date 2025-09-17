using Microsoft.AspNetCore.Identity;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Command.Auth;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Auth
{
    public class AuthCommandRepository : IAuthCommandRepository
    {
        private readonly UserManager<CustomUserEntity> _userManager;
        public AuthCommandRepository(UserManager<CustomUserEntity> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> Register(CustomUserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
