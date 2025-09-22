namespace ApiCallService.ApplicationContract.DTO.Internal.Product
{
    public class ProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
    }
}
