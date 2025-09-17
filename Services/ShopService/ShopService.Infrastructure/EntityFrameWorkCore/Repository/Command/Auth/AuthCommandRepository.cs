using Microsoft.AspNetCore.Identity;
using Second.Domain.Entities;
using Second.InfrastructureContract.Interfaces.Command.Auth;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Command.Auth
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
