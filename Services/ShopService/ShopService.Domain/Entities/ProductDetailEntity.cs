using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Domain.Entities
{
    public class ProductDetailEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))] 
        public ProductEntity Product { get; set; }
    }
}
