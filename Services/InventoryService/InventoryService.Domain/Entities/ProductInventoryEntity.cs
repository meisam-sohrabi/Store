using System.ComponentModel.DataAnnotations;

namespace InventoryService.Domain.Entities
{
    public class ProductInventoryEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int QuantityChange { get; set; }
        public DateTime ChangeDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
    }
}
