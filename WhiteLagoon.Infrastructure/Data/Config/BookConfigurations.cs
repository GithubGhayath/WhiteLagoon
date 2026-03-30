using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data.Config
{
    public class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.CheckInDate).IsRequired();
            builder.Property(b => b.Nights).IsRequired();
            builder.Property(b => b.CheckOutDate).IsRequired();
            builder.Property(b => b.Guests).IsRequired();
            builder.Property(b => b.PricePerNight).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(b => b.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(b => b.CreatedAt).IsRequired();


            builder.HasIndex(b => b.UserId);
            builder.HasIndex(b => b.VillaId);
            builder.HasIndex(b => b.StatusId);
            builder.HasIndex(b => b.CheckInDate);
            builder.HasIndex(b => b.CheckOutDate);

            builder.HasOne(b => b.User).WithMany(u => u.Books).HasForeignKey(b => b.UserId).IsRequired(true);
            builder.HasOne(b => b.Villa).WithMany(v => v.Books).HasForeignKey(b => b.VillaId).IsRequired(true);


        }
    }
}
