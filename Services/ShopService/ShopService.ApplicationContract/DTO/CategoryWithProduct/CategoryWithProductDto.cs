using Second.ApplicationContract.DTO.Category;
using Second.ApplicationContract.DTO.Product;

namespace Second.ApplicationContract.DTO.CategoryWithProduct
{
    public class CategoryWithProductDto
    {
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
    }
}
