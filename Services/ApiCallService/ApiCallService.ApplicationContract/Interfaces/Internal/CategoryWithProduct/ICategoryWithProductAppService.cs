using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.CategoryWithProduct;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct
{
    public interface ICategoryWithProductAppService
    {
        Task<BaseResponseDto<CategoryWithProductDto>> CreateCategoryWithProduct(CategoryWithProductDto categoryWithProductDto);
    }
}
