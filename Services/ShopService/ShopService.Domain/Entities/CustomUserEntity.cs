using Microsoft.AspNetCore.Identity;

namespace ShopService.Domain.Entities
{
    public class CustomUserEntity  : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
        public ICollection<UserPermissoinEntity> UserPermissions { get; set; } = new List<UserPermissoinEntity>();

    }
}
