using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.Account;
using First.ApplicationContract.DTO.Internal.Security;

namespace First.InfrastructureContract.Interfaces.Internal.Authentication
{
    public interface IAuthentication
    {
        Task<BaseResponseDto<ShowUserInfoDto>> Register(CreateUserDto createUserDto);
        Task<BaseResponseDto<TokenDto>> Login(LoginDto loginDto);
        Task<BaseResponseDto<bool>> Logout();
        Task<BaseResponseDto<TokenDto>> RefreshTokenRequest(RefreshTokenRequestDto tokenRequestDto);

    }
}
