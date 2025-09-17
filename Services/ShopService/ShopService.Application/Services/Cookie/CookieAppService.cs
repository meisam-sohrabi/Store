using Microsoft.AspNetCore.Http;
using ShopService.ApplicationContract.Interfaces;

namespace ShopService.Application.Services.Cookie
{
    public class CookieAppService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieAppService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool DeleteCookie(string key)
        {
            var keyExist = _httpContextAccessor.HttpContext?.Request.Cookies[key];
            if (keyExist == null)
            {
                return false;
            }
            _httpContextAccessor.HttpContext?.Response.Cookies.Delete(key);
            return true;
        }

        public string GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies[key];
        }

        public void SetCookie(string key, string value, TimeSpan? expireTime = null)
        {
            var option = new CookieOptions
            {
                HttpOnly = true,
                //Secure = true,
            };
            if (expireTime.HasValue)
            {
                option.Expires = DateTimeOffset.Now.Add(expireTime.Value);

            }
            _httpContextAccessor.HttpContext?.Response.Cookies.Append(key, value, option);
        }

    }
}
