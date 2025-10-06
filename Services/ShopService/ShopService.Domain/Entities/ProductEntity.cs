using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Domain.Entities
{
    public class ProductEntity: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; }

        public int ProductBrandId { get; set; }
        [ForeignKey(nameof(ProductBrandId))]
        public ProductBrandEntity ProductBrand { get; set; }

        public ICollection<ProductDetailEntity> ProductDetails { get; set; } = new List<ProductDetailEntity>();
        public ICollection<ProductPriceEntity> ProductPrices { get; set; } = new List<ProductPriceEntity>();
        public ICollection<ProductInventoryEntity> ProductInventories { get; set; } = new List<ProductInventoryEntity>();
    }
}
