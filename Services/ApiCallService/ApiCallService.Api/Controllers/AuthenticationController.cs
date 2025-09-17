using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Account;
using ApiCallService.ApplicationContract.DTO.Internal.Security;
using ApiCallService.ApplicationContract.Interfaces.Internal.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthenticationController(IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }
        [HttpPost("Register")]
        public async Task<BaseResponseDto<ShowUserInfoDto>> Register([FromBody] CreateUserDto createUserDto)
        {
            return await _authenticationAppService.Register(createUserDto);
        }


        [HttpPost("Login")]
        public async Task<BaseResponseDto<TokenDto>> Login([FromBody]LoginDto loginDto)
        {
            return await _authenticationAppService.Login(loginDto);
        }

        [HttpPost("Refresh")]
        public async Task<BaseResponseDto<TokenDto>> RefreshToken([FromBody]RefreshTokenRequestDto refreshTokenDto)
        {
            return await _authenticationAppService.RefreshTokenRequest(refreshTokenDto);
        }

        [HttpGet("Logout")]
        public async Task<BaseResponseDto<bool>> Logout()
        {
            return await _authenticationAppService.Logout();
        }
    }
}
