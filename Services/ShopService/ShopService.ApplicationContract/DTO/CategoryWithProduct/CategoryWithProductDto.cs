using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.DTO.Product;

namespace ShopService.ApplicationContract.DTO.CategoryWithProduct
{
    public class CategoryWithProductDto
    {
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
    }
}
