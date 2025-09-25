using Microsoft.AspNetCore.Identity;

namespace ShopService.Domain.Entities
{
    public class CustomUserEntity  : IdentityUser
    {
        public string FullName { get; set; }
        public RefreshTokenEntity RefreshToken { get; set; }
        public ICollection<UserSessionEntity> Sessions { get; set; } = new List<UserSessionEntity>();
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
        public ICollection<UserPermissoinEntity > UserPermissions { get; set; } = new List<UserPermissoinEntity>();

    }
}
