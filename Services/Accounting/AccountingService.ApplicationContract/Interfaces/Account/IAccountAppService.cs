using AccountingService.ApplicationContract.DTO.Account;
using AccountingService.ApplicationContract.DTO.Base;

namespace AccountingService.ApplicationContract.Interfaces.Account
{
    public interface IAccountAppService
    {
        Task<BaseResponseDto<ShowUserInfoDto>> ShowInfo();
        Task<BaseResponseDto<ShowUserInfoDto>> CreateUser(CreateUserDto createUserDto);
        Task<BaseResponseDto<ShowUserInfoDto>> EditUser(CreateUserDto createUserDto,string username);
        Task<BaseResponseDto<ShowUserInfoDto>> DeleteUser(string username);
    }
}
