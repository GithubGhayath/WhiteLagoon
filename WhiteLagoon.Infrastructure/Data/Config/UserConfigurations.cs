using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data.Config
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.Property(u => u.UserName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired(true);
            builder.Property(u => u.Password).HasColumnType("NVARCHAR").HasMaxLength(200).IsRequired(true);
            builder.Property(u => u.FullName).HasColumnType("NVARCHAR").HasMaxLength(200).IsRequired(true);
            builder.Property(u => u.PhoneNumber).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired(true);
            builder.Property(u => u.Email).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.CreatedAt).HasColumnType("datetime2").IsRequired(false);
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime2").IsRequired(false);
        }
    }
}
