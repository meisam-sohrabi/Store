using System.ComponentModel.DataAnnotations;

namespace ShopService.Domain.Entities
{
    public class CustomUserEntity
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }

    }
}
