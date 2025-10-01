using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class UserSessionEntityConfiguration : IEntityTypeConfiguration<UserSessionEntity>
    {
        public void Configure(EntityTypeBuilder<UserSessionEntity> builder)
        {
            builder.ToTable("UserSessions");
            builder.HasKey(e => e.Id);
        }
    }
}
