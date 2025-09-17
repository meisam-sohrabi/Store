using Microsoft.AspNetCore.Http;
using ShopService.ApplicationContract.Interfaces;
using System.Security.Claims;

namespace ShopService.Application.Services.User
{
    public class UserAppService : IUserAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAppService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return "0";
            }
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                return "0";
            }
            return userId;
        }
    }
}
