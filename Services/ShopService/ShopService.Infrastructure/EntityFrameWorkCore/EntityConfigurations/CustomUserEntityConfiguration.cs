using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class CustomUserEntityConfiguration : IEntityTypeConfiguration<CustomUserEntity>
    {
        public void Configure(EntityTypeBuilder<CustomUserEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("AspNetUsers", c => c.ExcludeFromMigrations());
        }
    }
}
