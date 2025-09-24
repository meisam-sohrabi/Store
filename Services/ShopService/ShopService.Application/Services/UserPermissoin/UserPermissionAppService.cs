using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.UserPermission;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.UserPermission;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.Permission;
using System.Net;

namespace ShopService.Application.Services.UserPermissoin
{
    public class UserPermissionAppService : IUserPermissionAppService
    {
        private readonly IUserPermissionCommandRepository _userPermissionCommanRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;
        private readonly IAccountQueryRepository _accountQueryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserPermissionAppService(IUserPermissionCommandRepository userPermissionCommanRepository
            , IPermissionQueryRepository permissionQueryRepository
            , IAccountQueryRepository accountQueryRepository
            , IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userPermissionCommanRepository = userPermissionCommanRepository;
            _permissionQueryRepository = permissionQueryRepository;
            _accountQueryRepository = accountQueryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #region Assign Permission
        public async Task<BaseResponseDto<UserPermissionDto>> AssignPermission(UserPermissionDto userPermissionDto)
        {
            var output = new BaseResponseDto<UserPermissionDto>
            {
                Message = "خطا در اختصاص پرمیژن به کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var permissionExist = await _permissionQueryRepository.GetQueryable().AnyAsync(c => c.Id == userPermissionDto.PermissionId);
            var userExist = await _accountQueryRepository.GetQueryable().FirstOrDefaultAsync(c => c.Id == userPermissionDto.UserId);
            if (userExist == null)
            {
                output.Message = "یوزر موردنظر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            if (!permissionExist)
            {
                output.Message = "پرمیژن موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map<UserPermissoinEntity>(userPermissionDto);
            await _userPermissionCommanRepository.AssignPermissionToUser(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"پرمیژن با موفقیت به کاربر اختصاص یافت";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Revoke Permission
        public async Task<BaseResponseDto<UserPermissionDto>> RevokePermission(UserPermissionDto userPermissionDto)
        {
            var output = new BaseResponseDto<UserPermissionDto>
            {
                Message = "خطا در سلب پرمیژن از کاربر",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var permissionExist = await _permissionQueryRepository.GetQueryable().AnyAsync(c => c.Id == userPermissionDto.PermissionId);
            var userExist = await _accountQueryRepository.GetQueryable().FirstOrDefaultAsync(c => c.Id == userPermissionDto.UserId);
            if (userExist == null)
            {
                output.Message = "یوزر موردنظر یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            if (!permissionExist)
            {
                output.Message = "پرمیژن موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map<UserPermissoinEntity>(userPermissionDto);
            _userPermissionCommanRepository.RevokePermissionFromUser(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"پرمیژن با موفقیت از کاربر سلب شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion


    }
}
