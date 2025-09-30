﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AccountingService.Domain.Entities;

namespace AccountingService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionEntity>
    {
        public void Configure(EntityTypeBuilder<PermissionEntity> builder)
        {
            builder.ToTable("Permissions");
            builder.HasKey(p => p.Id);// Permission can be unique 
            builder.Property(p => p.Resource).IsRequired();
            builder.Property(p => p.Action).IsRequired();
        }
    }
}
