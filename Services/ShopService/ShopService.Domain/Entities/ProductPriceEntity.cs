using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Domain.Entities
{
    public class ProductPriceEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime SetDate { get; set; } = DateTime.Now;

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))] 
        public ProductEntity? Product { get; set; }
    }
}
