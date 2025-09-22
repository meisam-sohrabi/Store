namespace ApiCallService.ApplicationContract.DTO.Internal.ProductDetail
{
    public class ProductDetailRequestDto
    {
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
    }
}
