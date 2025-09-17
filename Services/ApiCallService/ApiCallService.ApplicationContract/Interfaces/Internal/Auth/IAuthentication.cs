using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Account;
using ApiCallService.ApplicationContract.DTO.Internal.Security;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.Auth
{
    public interface IAuthentication
    {
        Task<BaseResponseDto<ShowUserInfoDto>> Register(CreateUserDto createUserDto);
        Task<BaseResponseDto<TokenDto>> Login(LoginDto loginDto);
        Task<BaseResponseDto<bool>> Logout();
        Task<BaseResponseDto<TokenDto>> RefreshTokenRequest(RefreshTokenRequestDto tokenRequestDto);

    }
}
