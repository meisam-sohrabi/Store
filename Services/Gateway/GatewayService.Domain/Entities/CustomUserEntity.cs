using Microsoft.AspNetCore.Identity;

namespace GatewayService.Domain.Entities
{
    public class CustomUserEntity : IdentityUser
    {
        public string FullName { get; set; }
        public RefreshTokenEntity RefreshToken { get; set; }

    }
}
