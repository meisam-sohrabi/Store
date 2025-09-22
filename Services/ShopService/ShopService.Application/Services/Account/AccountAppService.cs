using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Account;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.Interfaces;
using ShopService.ApplicationContract.Interfaces.Account;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Account;
using ShopService.InfrastructureContract.Interfaces.Command.Security;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.Security;
using System.Net;

namespace ShopService.Application.Services.Account
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;

        public AccountAppService(IAccountCommandRepository accountCommandRepository, IAccountQueryRepository accountQueryRepository)
        {
            _accountCommandRepository = accountCommandRepository;
            _accountQueryRepository = accountQueryRepository;
        }

        #region GetUser
        public async Task<BaseResponseDto<ShowUserInfoDto>> GetUser(string userName)
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در دریافت کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var user = await _accountQueryRepository.GetQueryable()
                .Where(c => c.UserName == userName)
                .Select(c => new ShowUserInfoDto
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber ?? "No phone number"
                })
                .FirstOrDefaultAsync();
            if (user == null)
            {
                output.Message = "کاربر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            output.Message = "کاربر یافت نشد";
            output.Success = false;
            output.Data = user;
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

    }
}
