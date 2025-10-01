using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Domain.Entities
{
    public class UserSessionEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime LoginTime { get; set; } = DateTime.Now;
        public DateTime? LogoutTime { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }

    }
}
