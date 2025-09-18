using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Security;
using ShopService.ApplicationContract.Interfaces.Atuh;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;

        public AuthenticationController(IAuthAppService authAppService)
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
        public async Task<BaseResponseDto<TokenDto>> RefreshToken([FromBody] RefreshTokenRequestDto refreshToken)
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
