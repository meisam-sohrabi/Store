using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.ProductDetail;
using ShopService.ApplicationContract.DTO.ProductPrice;

namespace ShopService.ApplicationContract.DTO.Transaction
{
    public class ProductTransactionDto
    {
        public ProductRequestDto Product { get; set; }
        public ProductDetailRequestDto ProductDetail { get; set; }
        public ProductPriceRequestDto ProductPrice { get; set; }

    }
}