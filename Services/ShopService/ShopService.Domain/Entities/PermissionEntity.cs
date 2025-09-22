using System.ComponentModel.DataAnnotations;

namespace ShopService.Domain.Entities
{
    public class PermissionEntity : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Resource { get; set; } 
        public string Action { get; set; }
        public string? Description { get; set; }
        public ICollection<CustomUserEntity> Users { get; set; } = new List<CustomUserEntity>();

    }
}
