using GatewayService.Domain.Entities;
using GatewayService.InfrastructureContract.Interfaces.Query.Auth;
using Microsoft.AspNetCore.Identity;

namespace GatewayService.Infrastructure.EntityFrameWorkCore.Repository.Query.Auth
{
    public class AuthQueryRepository : IAuthQueryRrepository
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

        public IQueryable<CustomUserEntity> GetQueryable()
        {
            return _userManager.Users.AsQueryable();
        }
    }
}
