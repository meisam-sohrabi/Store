using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Category;

namespace ShopService.ApplicationContract.Interfaces.Category
{
    public interface ICategoryAppService
    {
        Task<BaseResponseDto<CategoryDto>> CreateCategory(CategoryDto categoryDto);
        Task<BaseResponseDto<CategoryDto>> EditCategory(int id, CategoryDto categoryDto);
        Task<BaseResponseDto<CategoryDto>> DeleteCategory(int id);
        Task<BaseResponseDto<List<CategoryDto>>> GetAllCategories();
        Task<BaseResponseDto<CategoryDto>> GetCategory(int id);
    }
}
