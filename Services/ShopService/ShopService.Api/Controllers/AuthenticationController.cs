using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Second.Application.Services.Auth;
using Second.ApplicationContract.DTO.Account;
using Second.ApplicationContract.DTO.Base;
using Second.ApplicationContract.DTO.Security;

namespace Second.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthAppService _authAppService;

        public AuthenticationController(AuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("Register")]
        public async Task<BaseResponseDto<ShowUserInfoDto>> Register([FromBody] CreateUserDto createUserDto)
        {
            return await _authAppService.Register(createUserDto);
        }


        [HttpPost("Login")]
        public async Task<BaseResponseDto<TokenDto>> Login([FromBody] LoginDto loginDto)
        {
            return await _authAppService.Login(loginDto);
        }

        [HttpPost("Refresh")]
        [Authorize]
        public async Task<BaseResponseDto<TokenDto>> RefreshToken([FromBody]RefreshTokenRequestDto refreshToken)
        {
            return await _authAppService.RefreshTokenRequest(refreshToken);
        }

        [HttpGet("Logout")]
        [Authorize]
        public async Task<BaseResponseDto<bool>> Logout()
        {
            return await _authAppService.Logout();
        }
    }
}
