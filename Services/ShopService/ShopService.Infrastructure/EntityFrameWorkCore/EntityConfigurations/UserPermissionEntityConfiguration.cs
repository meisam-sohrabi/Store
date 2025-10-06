using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class UserPermissionEntityConfiguration : IEntityTypeConfiguration<UserPermissoinEntity>
    {
        public void Configure(EntityTypeBuilder<UserPermissoinEntity> builder)
        {
            builder.ToTable("UserPermissions",c=> c.ExcludeFromMigrations());
            builder.HasKey(up => new { up.PermissionId, up.UserId });

            builder.HasOne(up => up.User)
            .WithMany()   // چون در این سرویس نیازی به ICollection<UserPermission> در User نداریم
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Permission)
           .WithMany()
           .HasForeignKey(up => up.PermissionId)
           .OnDelete(DeleteBehavior.Cascade);

            // mishe as usingentity ham estefade kard.
        }
    }
}
