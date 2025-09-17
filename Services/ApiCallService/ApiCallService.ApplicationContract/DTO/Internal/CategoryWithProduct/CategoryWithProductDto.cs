using ApiCallService.ApplicationContract.DTO.Internal.Category;
using ApiCallService.ApplicationContract.DTO.Internal.Product;

namespace ApiCallService.ApplicationContract.DTO.Internal.CategoryWithProduct
{
    public class CategoryWithProductDto
    {
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
    }
}
