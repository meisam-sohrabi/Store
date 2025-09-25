namespace ShopService.ApplicationContract.DTO.Order
{
    public class ShowOrderDto
    {
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; }
    }
}
