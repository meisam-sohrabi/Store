using Microsoft.AspNetCore.Identity;

namespace Second.Domain.Entities
{
    public class CustomUserEntity  : IdentityUser
    {
        public string FullName { get; set; }
        public RefreshTokenEntity RefreshToken { get; set; }
        public ICollection<UserSessionEntity> Sessions { get; set; } = new List<UserSessionEntity>();

    }
}
