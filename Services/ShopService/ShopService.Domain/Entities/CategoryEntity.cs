using System.ComponentModel.DataAnnotations;

namespace Second.Domain.Entities
{
    public class CategoryEntity: BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
