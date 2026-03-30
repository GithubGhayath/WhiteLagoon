using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data.Config
{
    public class PaymentConfigurations : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p => p.Currency) .HasColumnType("NVARCHAR(10)").HasDefaultValue("USD").IsRequired();
            builder.Property(p => p.TransactionId).HasColumnType("NVARCHAR(200)").IsRequired(false);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.CompletedAt).IsRequired(false);
            builder.HasIndex(p => p.UserId);
            builder.HasIndex(p => p.PaymentMethodId);
            builder.HasIndex(p => p.PaymentStatusId);
            builder.HasIndex(p => p.TransactionId);

            builder.HasOne(p => p.PaymentMethod).WithMany(pm => pm.Payments).HasForeignKey(p => p.PaymentMethodId).IsRequired(true);
            builder.HasOne(p => p.PaymentStatus).WithMany(ps => ps.Payments).HasForeignKey(p => p.PaymentStatusId).IsRequired(true);
            builder.HasOne(p => p.User).WithMany(u => u.Payments).HasForeignKey(p => p.UserId).IsRequired(true);

        }
    }
}
