using ApiCallService.ApplicationContract.DTO.Internal.Category;
using ApiCallService.ApplicationContract.DTO.Internal.Product;
using ApiCallService.ApplicationContract.DTO.Internal.ProductBrand;
using ApiCallService.ApplicationContract.DTO.Internal.ProductDetail;

namespace ApiCallService.ApplicationContract.DTO.Internal.Transaction
{
    public class ProductTransactionDto
    {
        public CategoryDto Category { get; set; }
        public ProductDto Product { get; set; }
        public ProductBrandDto ProductBrand { get; set; }
        public ProductDetailDto ProductDetail { get; set; }
    }
}
