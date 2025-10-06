using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GatewayService.Domain.Entities
{
    public class CustomUserEntity 
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        //public RefreshTokenEntity RefreshToken { get; set; }

    }
}
