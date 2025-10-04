﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AccountingService.Domain.Entities;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class UserPermissionEntityConfiguration : IEntityTypeConfiguration<UserPermissoinEntity>
    {
        public void Configure(EntityTypeBuilder<UserPermissoinEntity> builder)
        {
            builder.ToTable("UserPermissions");
            builder.HasKey(up => new { up.PermissionId, up.UserId });

            builder.HasOne(up => up.User)
            .WithMany(u => u.UserPermissions)
            .HasForeignKey(up => up.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Permission)
           .WithMany(p => p.UserPermissions)
           .HasForeignKey(up => up.PermissionId)
           .OnDelete(DeleteBehavior.Cascade);

            // mishe as usingentity ham estefade kard.
        }
    }
}
