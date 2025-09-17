using AutoMapper;
using LogService;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.Interfaces;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces;
using ShopService.InfrastructureContract.Interfaces.Command.Category;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using System.Net;

using System.Text.Json;
namespace ShopService.Application.Services.Category
{
    public class CategoryAppService
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogAppService  _logAppService;
        private readonly IUserAppService _userAppService;

        public CategoryAppService(ICategoryQueryRepository categoryQueryRepository, ICategoryCommandRepository categoryCommandRepository, IUnitOfWork unitOfWork
            ,IMapper mapper, ILogAppService logAppService,IUserAppService userAppService)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _categoryCommandRepository = categoryCommandRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logAppService = logAppService;
            _userAppService = userAppService;
        }

        #region Create
        public async Task<BaseResponseDto<CategoryDto>> CreateCategory(CategoryDto category)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در درج دسته بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var currentUserId = _userAppService.GetCurrentUser();
            var categoryExist = await GetCategoryByName(category.Name);
            if(categoryExist.Success)
            {
                output.Message = "دسته بندی از قبل ثبت شده است";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotAcceptable;
                return output;
            }
            var mapped = _mapper.Map<CategoryEntity>(category);
            _categoryCommandRepository.Add(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = $"دسته بندی {category.Name} با موفقیت درج شد";
                output.Success = true;
            }
            await _logAppService.LogAsync(JsonSerializer.Serialize(mapped), "Category",currentUserId);
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<CategoryDto>> EditCategory(int id, CategoryDto category)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در به روز رسانی دسته بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var categoryexist = await _categoryQueryRepository.GetQueryable()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (categoryexist == null)
            {
                output.Message = "دسته بندی یافت نشد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            var mapped = _mapper.Map(category, categoryexist);
            _categoryCommandRepository.Edit(mapped);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = "دسته بندی با موفقیت به روزرسانی شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<CategoryDto>> DeleteCategory(int id)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در حذف دسته بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var categoryexist = await _categoryQueryRepository.GetQueryable()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoryexist == null)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }
            if (categoryexist.Products.Any())
            {
                output.Message = "دسته بندی مورد نظر دارای محصولات می باشد امکان حذف وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.BadRequest;
                return output;
            }

            _categoryCommandRepository.Delete(categoryexist);
            var affectedRows = await _unitOfWork.SaveChangesAsync();
            if (affectedRows > 0)
            {
                output.Message = "دسته‌بندی با موفقیت حذف شد";
                output.Success = true;
            }
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<CategoryDto>>> GetAllCategories()
        {
            var output = new BaseResponseDto<List<CategoryDto>>
            {
                Message = "خطا در بازیابی دسته‌بندی ها",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var categories = await _categoryQueryRepository.GetQueryable()
                .Select(c => new CategoryDto { Name = c.Name, IsActive = c.IsActive })
                .ToListAsync();
            if (!categories.Any())
            {
                output.Message = "دسته‌بندی های موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            output.Message = "دسته‌بندی ها با موفقیت دریافت شد";
            output.Success = true;
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            output.Data = categories;

            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<CategoryDto>> GetCategory(int id)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در بازیابی دسته‌بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var category = await _categoryQueryRepository.GetQueryable()
                .Where(c => c.Id == id)
                .Select(c => new CategoryDto { Name = c.Name, IsActive = c.IsActive })
                .FirstOrDefaultAsync();
            if (category == null)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            output.Message = "دسته‌بندی با موفقیت دریافت شد";
            output.Success = true;
            output.StatusCode = output.Success ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            output.Data = category;

            return output;
        }
        #endregion

        #region GetByName
        private async Task<BaseResponseDto<bool>> GetCategoryByName(string name)
        {
            var output = new BaseResponseDto<bool>
            {
                Message = "خطا در بازیابی دسته‌بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var category = await _categoryQueryRepository.GetQueryable()
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync();
            if (category == null)
            {
                output.Message = "دسته‌بندی موردنظر وجود ندارد";
                output.Success = false;
                output.StatusCode = HttpStatusCode.NotFound;
                return output;
            }

            output.Message = "دسته‌بندی با موفقیت دریافت شد";
            output.Success = true;
            output.StatusCode = HttpStatusCode.OK;
            output.Data = true;

            return output;
        }
        #endregion

    }
}
