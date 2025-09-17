using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.Category;

namespace First.InfrastructureContract.Interfaces.Internal.Category
{
    public interface ICategoryApi
    {
        Task<BaseResponseDto<List<CategoryDto>>> GetAllCategoriesAsync();
        Task<BaseResponseDto<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<BaseResponseDto<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto);
        Task<BaseResponseDto<CategoryDto>> EditCategoryAsync(int id, CategoryDto categoryDto);
        Task<BaseResponseDto<CategoryDto>> DeleteCategoryAsync(int id);
    }
}
