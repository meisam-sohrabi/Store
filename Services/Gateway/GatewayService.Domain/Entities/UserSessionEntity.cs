using System.ComponentModel.DataAnnotations.Schema;

namespace GatewayService.Domain.Entities
{
    public class UserSessionEntity
    {
        public int Id { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.Now;
        public DateTime? LogoutTime { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public CustomUserEntity User { get; set; }
    }
}
