using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Category;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.Category
{
    public interface ICategoryAppService
    {
        Task<BaseResponseDto<List<CategoryDto>>> GetAllCategoriesAsync();
        Task<BaseResponseDto<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<BaseResponseDto<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto);
        Task<BaseResponseDto<CategoryDto>> EditCategoryAsync(int id, CategoryDto categoryDto);
        Task<BaseResponseDto<CategoryDto>> DeleteCategoryAsync(int id);
    }
}
