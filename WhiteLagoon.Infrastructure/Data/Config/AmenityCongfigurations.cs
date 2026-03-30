using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data.Config
{
    public class AmenityCongfigurations : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.ToTable("Amenities");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasMaxLength(200).HasColumnType("NVARCHAR").IsRequired(true);
            builder.Property(a => a.Description).HasMaxLength(500).HasColumnType("NVARCHAR").IsRequired(true);
            builder.HasOne(a => a.Villa).WithMany(v => v.Amenities).HasForeignKey(a=>a.VillaId).IsRequired(true);
        }
    }
}
