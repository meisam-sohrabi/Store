using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.CategoryWithProduct;

namespace First.InfrastructureContract.Interfaces.Internal.CategoryWithProduct
{
    public interface ICategoryWithProductApi
    {
        Task<BaseResponseDto<CategoryWithProductDto>> CreateCategoryWithProduct(CategoryWithProductDto categoryWithProductDto);
    }
}
