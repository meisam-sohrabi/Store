using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderedAt { get; set; } 
        public int ProductId { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public CustomUserEntity User { get; set; }
    }
}
