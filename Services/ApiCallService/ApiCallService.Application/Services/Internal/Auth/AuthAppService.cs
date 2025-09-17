using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.Account;
using First.ApplicationContract.DTO.Internal.Security;
using First.InfrastructureContract.Interfaces.Internal.Authentication;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace First.Application.Services.Internal.Account
{
    public class AuthAppService : IAuthentication
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthAppService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }
        #region Login
        public async Task<BaseResponseDto<TokenDto>> Login(LoginDto loginDto)
        {
            var output = new BaseResponseDto<TokenDto>
            {
                Message = "خطا در ورود کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var response = await _client.PostAsJsonAsync("https://localhost:44358/Authentication/Login", loginDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<TokenDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion


        #region Register
        public async Task<BaseResponseDto<ShowUserInfoDto>> Register(CreateUserDto createUserDto)
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در درج کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var response = await _client.PostAsJsonAsync("https://localhost:44358/Authentication/Register", createUserDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ShowUserInfoDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region Logout
        public async Task<BaseResponseDto<bool>> Logout()
        {
            var output = new BaseResponseDto<bool>
            {
                Message = "خطا در ورود کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync("https://localhost:44358/Authentication/Logout");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<bool>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region RefreshToken
        public async Task<BaseResponseDto<TokenDto>> RefreshTokenRequest(RefreshTokenRequestDto refreshToken)
        {
            var output = new BaseResponseDto<TokenDto>
            {
                Message = "خطا در ورود کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync("https://localhost:44358/Authentication/Refresh", refreshToken);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<TokenDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion
    }
}
