using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductBrand;
using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.ApplicationContract.DTO.Transaction
{
    public class ProductTransactionDto
    {
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
        public ProductBrandDto ProductBrand { get; set; }
        public ProductDetailDto ProductDetail { get; set; }
    }
}