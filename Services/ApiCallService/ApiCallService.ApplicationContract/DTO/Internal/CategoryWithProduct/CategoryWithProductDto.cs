using First.ApplicationContract.DTO.Internal.Category;
using First.ApplicationContract.DTO.Internal.Product;

namespace First.ApplicationContract.DTO.Internal.CategoryWithProduct
{
    public class CategoryWithProductDto
    {
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
    }
}
