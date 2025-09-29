using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GatewayService.Domain.Entities
{
    public class RefreshTokenEntity
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public CustomUserEntity? User { get; set; }
    }
}
