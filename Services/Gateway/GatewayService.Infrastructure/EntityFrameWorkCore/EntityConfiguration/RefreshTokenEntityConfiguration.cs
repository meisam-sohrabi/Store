﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GatewayService.Domain.Entities;

namespace GatewayService.Infrastructure.EntityFrameWorkCore.EntityConfiguration
{
    public class RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.ToTable("RefreshToken");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Token).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
        }
    }
}
