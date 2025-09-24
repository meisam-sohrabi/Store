using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Permission;
using ShopService.ApplicationContract.Interfaces.Permission;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Permission;
using ShopService.InfrastructureContract.Interfaces.Query.Permission;
using System.Net;

namespace ShopService.Application.Services.Permission
{
    public class PermissionAppService : IPermissionAppService
    {
        private readonly IPermissionCommandRepository _permissionCommandRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionAppService(IPermissionCommandRepository permissionCommandRepository
            , IPermissionQueryRepository permissionQueryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _permissionCommandRepository = permissionCommandRepository;
            _permissionQueryRepository = permissionQueryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        #region Create
        public async Task<BaseResponseDto<PermissionDto>> CreatePermission(PermissionDto permissionDto)
        {
            var output = new BaseResponseDto<PermissionDto>
            {
                Message = "خطا در ایجاد پرمیژن",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var permissionExist = await _permissionQueryRepository.GetQueryable().AnyAsync(c => c.Resource == permissionDto.Resource && c.Action == permissionDto.Action);
            if (permissionExist)
            {
                output.Message = "پرمیژن موردنظر وجود دارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.Conflict;
                return output;
            }
            var mapped = _mapper.Map<PermissionEntity>(permissionDto);
            _permissionCommandRepository.Add(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"پرمیژن  با موفقیت ایجاد شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<PermissionDto>> DeletePermission(int id)
        {
            var output = new BaseResponseDto<PermissionDto>
            {
                Message = "خطا در حذف پرمیژن",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var permissionExist = await _permissionQueryRepository.GetQueryable().FirstOrDefaultAsync(c => c.Id == id);
            if (permissionExist == null)
            {
                output.Message = "پرمیژن موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.Conflict;
                return output;
            }
            _permissionCommandRepository.Delete(permissionExist);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"پرمیژن  با موفقیت حذف شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<PermissionDto>> EditPermission(int id, PermissionDto permissionDto)
        {
            var output = new BaseResponseDto<PermissionDto>
            {
                Message = "خطا در به روز رسانی پرمیژن",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var permissionExist = await _permissionQueryRepository.GetQueryable().FirstOrDefaultAsync(c => c.Id == id);
            if (permissionExist == null)
            {
                output.Message = "پرمیژن موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.Conflict;
                return output;
            }
            var mapped = _mapper.Map(permissionDto, permissionExist);
            _permissionCommandRepository.Update(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"پرمیژن  با موفقیت به روز رسانی شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<PermissionDto>>> GetAllPermissions()
        {
            var output = new BaseResponseDto<List<PermissionDto>>
            {
                Message = "خطا در ایجاد پرمیژن",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var permissionExist = await _permissionQueryRepository.GetQueryable().ToListAsync();
            if (permissionExist == null)
            {
                output.Message = "پرمیژن موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.Conflict;
                return output;
            }
            var mapped = _mapper.Map<List<PermissionDto>>(permissionExist);
            output.Message = "پرمیژن ها با موفقیت به دریافت  شدند";
            output.Success = true;
            output.Data = mapped;
            output.StatusCode = output.Success ? HttpStatusCode.OK : output.StatusCode;
            return output;
            #endregion

        }
    }
}
