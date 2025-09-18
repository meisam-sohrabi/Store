using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Security;

namespace ShopService.ApplicationContract.Interfaces.Atuh
{
    public interface IAuthAppService
    {
        Task<BaseResponseDto<ShowUserInfoDto>> Register(CreateUserDto createUserDto);
        Task<BaseResponseDto<TokenDto>> Login(LoginDto loginDto);
        Task<BaseResponseDto<bool>> Logout();
        Task<BaseResponseDto<TokenDto>> RefreshTokenRequest(RefreshTokenRequestDto refreshToken);
    }
}
