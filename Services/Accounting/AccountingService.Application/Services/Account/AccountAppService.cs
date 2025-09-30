using AccountingService.ApplicationContract.DTO.Account;
using AccountingService.ApplicationContract.DTO.Base;
using AccountingService.ApplicationContract.Interfaces;
using AccountingService.ApplicationContract.Interfaces.Account;
using AccountingService.Domain.Entities;
using AccountingService.InfrastructureContract.Interfaces;
using AccountingService.InfrastructureContract.Interfaces.Command.Account;
using AccountingService.InfrastructureContract.Interfaces.Command.Role;
using AccountingService.InfrastructureContract.Interfaces.Query.Account;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AccountingService.Application.Services.Account
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountCommandRepository _accountCommandRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IUserAppService _userAppService;
        private readonly IMapper _mapper;
        private readonly IRoleCommandRepository _roleCommandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountAppService(IAccountCommandRepository accountCommandRepository
            , IAccountQueryRepository accountQueryRepository
            , IUserAppService userAppService
            ,IMapper mapper
            ,IRoleCommandRepository roleCommandRepository,
            IUnitOfWork unitOfWork)
        {
            _accountCommandRepository = accountCommandRepository;
            _accountQueryRepository = accountQueryRepository;
            _userAppService = userAppService;
            _mapper = mapper;
            _roleCommandRepository = roleCommandRepository;
            _unitOfWork = unitOfWork;
        }

        #region Create
        public async Task<BaseResponseDto<ShowUserInfoDto>> CreateUser(CreateUserDto createUserDto)
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در ایجاد کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var identityUser = new CustomUserEntity
            {
                FullName = createUserDto.FullName,
                Email = createUserDto.Email,
                UserName = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber
            };
            var result = await _accountCommandRepository.Create(identityUser, createUserDto.Password);
            if (!result.Succeeded)
            {
                output.Message = "خطا در ایحاد کاربر";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }
            await _roleCommandRepository.AssignRoleToUser(identityUser, "user");

            output.Message = "کاربر با موفقبت ایجاد شد";
            output.Success = true;
            output.Data = _mapper.Map<ShowUserInfoDto>(identityUser);

            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }

        #endregion

        #region Edit
        public async Task<BaseResponseDto<ShowUserInfoDto>> EditUser(CreateUserDto createUserDto, string username)
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در به روزرسانی کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var userExist = await _accountQueryRepository.GetQueryable().FirstOrDefaultAsync(c => c.UserName == username);
            if (userExist == null)
            {
                output.Message = "کاربر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map(createUserDto, userExist);
            _accountCommandRepository.Update(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = "کاربر با موفقیت به روزرسانی شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ShowUserInfoDto>> DeleteUser(string username)
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در به حذف کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var userExist = await _accountQueryRepository.GetQueryable().FirstOrDefaultAsync(c => c.UserName == username);
            if (userExist == null)
            {
                output.Message = "کاربر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            await _accountCommandRepository.Delete(userExist);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = "کاربر با موفقیت به حذف شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return output;
        }


        #endregion

        #region ShowInfo
        public async  Task<BaseResponseDto<ShowUserInfoDto>> ShowInfo()
        {
            var output = new BaseResponseDto<ShowUserInfoDto>
            {
                Message = "خطا در دریافت کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var userId = _userAppService.GetCurrentUser();
            var user = await _accountQueryRepository.GetQueryable().Where(c => c.Id == userId).Select(c => new ShowUserInfoDto
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
