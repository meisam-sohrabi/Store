using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GatewayService.Domain.Entities;

namespace GatewayService.Infrastructure.EntityFrameWorkCore.EntityConfiguration
{
    public class CustomUserEntityConfiguration : IEntityTypeConfiguration<CustomUserEntity>
    {
        public void Configure(EntityTypeBuilder<CustomUserEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.RefreshToken).WithOne(e => e.User).HasForeignKey<RefreshTokenEntity>(c=> c.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
