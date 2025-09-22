using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Base;

namespace ShopService.ApplicationContract.Interfaces.Account
{
    public interface IAccountAppService
    {
        Task<BaseResponseDto<ShowUserInfoDto>> GetUser(string userName);
    }
}
