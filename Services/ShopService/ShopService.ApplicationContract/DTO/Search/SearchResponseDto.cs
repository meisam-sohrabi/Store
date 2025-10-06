using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.ApplicationContract.DTO.Search
{
    public class SearchResponseDto
    {
        public string categoryName { get; set; }
        public string productBrand { get; set; }
        public string produtName { get; set; }
        public List<ProductDetailResponseDto> productDetail { get; set; }
        public Decimal Price { get; set; }
    }
}
