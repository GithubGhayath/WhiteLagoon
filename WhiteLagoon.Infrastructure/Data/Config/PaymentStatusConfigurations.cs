using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data.Config
{
    public class PaymentStatusConfigurations : IEntityTypeConfiguration<PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<PaymentStatus> builder)
        {
            builder.ToTable("PaymentStatues");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Status).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired(true);
            builder.Property(p => p.Description).HasColumnType("VARCHAR").HasMaxLength(500).IsRequired(true);

        }
    }
}
