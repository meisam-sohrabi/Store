﻿using Microsoft.AspNetCore.Http;
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
            if (!_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
            {
                return "0";
            }
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(userId == null)
            {
                return "0";
            }
            return userId;
        }
    }
}
