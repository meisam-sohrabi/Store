using Microsoft.AspNetCore.Identity;

namespace AccountingService.Domain.Entities
{
    public class CustomUserEntity  : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<UserPermissoinEntity> UserPermissions { get; set; } = new List<UserPermissoinEntity>();


    }
}
