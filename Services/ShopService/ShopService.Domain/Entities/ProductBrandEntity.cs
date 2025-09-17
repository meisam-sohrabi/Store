using System.ComponentModel.DataAnnotations;

namespace ShopService.Domain.Entities
{
    public class ProductBrandEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
