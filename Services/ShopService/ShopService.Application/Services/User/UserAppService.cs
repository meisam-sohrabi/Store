using Microsoft.AspNetCore.Http;
using Second.ApplicationContract.Interfaces;
using System.Security.Claims;

namespace Second.Application.Services.User
{
    internal class UserAppService : IUserAppService
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public UserAppService(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return 0;
            }
            var userId = user.FindFirstValue(ClaimTypes)

        }
    }
}
