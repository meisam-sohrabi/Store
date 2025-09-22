using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.ApplicationContract.DTO.Transaction
{
    public class ProductTransactionDto
    {
        public ProductRequestDto Product { get; set; }
        public ProductDetailRequestDto ProductDetail { get; set; }
        public int CategoryId { get; set; }
        public int ProductBrandId { get; set; }

    }
}