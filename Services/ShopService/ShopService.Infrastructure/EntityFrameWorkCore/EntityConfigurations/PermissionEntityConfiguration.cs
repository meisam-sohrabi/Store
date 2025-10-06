using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("Permissions", c => c.ExcludeFromMigrations());
            builder.HasKey(p => p.Id);

        }
    }
}
