using System.ComponentModel.DataAnnotations;

namespace GatewayService.Domain.Entities
{
    public class CustomRoleEntity
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
