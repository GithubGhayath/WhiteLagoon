using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WhiteLagoon.Domain.Entities;

namespace WhiteLagoon.Infrastructure.Data.Config
{
    public class VillaNumberConfigurations : IEntityTypeConfiguration<VillaNumber>
    {
        public void Configure(EntityTypeBuilder<VillaNumber> builder)
        {
            builder.HasKey(v => v.Villa_Number);
            builder.Property(v => v.Villa_Number).ValueGeneratedNever();
            builder.Property(v => v.SpecialDetails).HasColumnType("NVARCHAR").HasMaxLength(500).IsRequired(false);
            builder.HasOne(vn => vn.Villa).WithMany(v => v.VillaNumbers).HasForeignKey(vn => vn.VillaId).IsRequired(true);
            builder.HasData(LoadVillaNumbers());
        }

        private List<VillaNumber> LoadVillaNumbers()
        {
            return new List<VillaNumber>
            {
                 // Villa 1
        new VillaNumber { Villa_Number = 101, VillaId = 1, SpecialDetails = "Villa 1 - Room 1" },
        new VillaNumber { Villa_Number = 102, VillaId = 1, SpecialDetails = "Villa 1 - Room 2" },
        new VillaNumber { Villa_Number = 103, VillaId = 1, SpecialDetails = "Villa 1 - Room 3" },

        // Villa 2
        new VillaNumber { Villa_Number = 201, VillaId = 2, SpecialDetails = "Villa 2 - Room 1" },
        new VillaNumber { Villa_Number = 202, VillaId = 2, SpecialDetails = "Villa 2 - Room 2" },
        new VillaNumber { Villa_Number = 203, VillaId = 2, SpecialDetails = "Villa 2 - Room 3" },

        // Villa 3
        new VillaNumber { Villa_Number = 301, VillaId = 3, SpecialDetails = "Villa 3 - Room 1" },
        new VillaNumber { Villa_Number = 302, VillaId = 3, SpecialDetails = "Villa 3 - Room 2" },
        new VillaNumber { Villa_Number = 303, VillaId = 3, SpecialDetails = "Villa 3 - Room 3" },

        // Villa 4
        new VillaNumber { Villa_Number = 401, VillaId = 4, SpecialDetails = "Villa 4 - Room 1" },
        new VillaNumber { Villa_Number = 402, VillaId = 4, SpecialDetails = "Villa 4 - Room 2" },
        new VillaNumber { Villa_Number = 403, VillaId = 4, SpecialDetails = "Villa 4 - Room 3" },

        // Villa 5
        new VillaNumber { Villa_Number = 501, VillaId = 5, SpecialDetails = "Villa 5 - Room 1" },
        new VillaNumber { Villa_Number = 502, VillaId = 5, SpecialDetails = "Villa 5 - Room 2" },
        new VillaNumber { Villa_Number = 503, VillaId = 5, SpecialDetails = "Villa 5 - Room 3" },

        // Villa 6
        new VillaNumber { Villa_Number = 601, VillaId = 6, SpecialDetails = "Villa 6 - Room 1" },
        new VillaNumber { Villa_Number = 602, VillaId = 6, SpecialDetails = "Villa 6 - Room 2" },
        new VillaNumber { Villa_Number = 603, VillaId = 6, SpecialDetails = "Villa 6 - Room 3" },

        // Villa 7
        new VillaNumber { Villa_Number = 701, VillaId = 7, SpecialDetails = "Villa 7 - Room 1" },
        new VillaNumber { Villa_Number = 702, VillaId = 7, SpecialDetails = "Villa 7 - Room 2" },
        new VillaNumber { Villa_Number = 703, VillaId = 7, SpecialDetails = "Villa 7 - Room 3" },

        // Villa 8
        new VillaNumber { Villa_Number = 801, VillaId = 8, SpecialDetails = "Villa 8 - Room 1" },
        new VillaNumber { Villa_Number = 802, VillaId = 8, SpecialDetails = "Villa 8 - Room 2" },
        new VillaNumber { Villa_Number = 803, VillaId = 8, SpecialDetails = "Villa 8 - Room 3" },

        // Villa 9
        new VillaNumber { Villa_Number = 901, VillaId = 9, SpecialDetails = "Villa 9 - Room 1" },
        new VillaNumber { Villa_Number = 902, VillaId = 9, SpecialDetails = "Villa 9 - Room 2" },
        new VillaNumber { Villa_Number = 903, VillaId = 9, SpecialDetails = "Villa 9 - Room 3" },

        // Villa 10
        new VillaNumber { Villa_Number = 1001, VillaId = 10, SpecialDetails = "Villa 10 - Room 1" },
        new VillaNumber { Villa_Number = 1002, VillaId = 10, SpecialDetails = "Villa 10 - Room 2" },
        new VillaNumber { Villa_Number = 1003, VillaId = 10, SpecialDetails = "Villa 10 - Room 3" },

        // Villa 11
        new VillaNumber { Villa_Number = 1101, VillaId = 11, SpecialDetails = "Villa 11 - Room 1" },
        new VillaNumber { Villa_Number = 1102, VillaId = 11, SpecialDetails = "Villa 11 - Room 2" },
        new VillaNumber { Villa_Number = 1103, VillaId = 11, SpecialDetails = "Villa 11 - Room 3" },

        // Villa 12
        new VillaNumber { Villa_Number = 1201, VillaId = 12, SpecialDetails = "Villa 12 - Room 1" },
        new VillaNumber { Villa_Number = 1202, VillaId = 12, SpecialDetails = "Villa 12 - Room 2" },
        new VillaNumber { Villa_Number = 1203, VillaId = 12, SpecialDetails = "Villa 12 - Room 3" },

        // Villa 13
        new VillaNumber { Villa_Number = 1301, VillaId = 13, SpecialDetails = "Villa 13 - Room 1" },
        new VillaNumber { Villa_Number = 1302, VillaId = 13, SpecialDetails = "Villa 13 - Room 2" },
        new VillaNumber { Villa_Number = 1303, VillaId = 13, SpecialDetails = "Villa 13 - Room 3" },

        // Villa 14
        new VillaNumber { Villa_Number = 1401, VillaId = 14, SpecialDetails = "Villa 14 - Room 1" },
        new VillaNumber { Villa_Number = 1402, VillaId = 14, SpecialDetails = "Villa 14 - Room 2" },
        new VillaNumber { Villa_Number = 1403, VillaId = 14, SpecialDetails = "Villa 14 - Room 3" },

        // Villa 15
        new VillaNumber { Villa_Number = 1501, VillaId = 15, SpecialDetails = "Villa 15 - Room 1" },
        new VillaNumber { Villa_Number = 1502, VillaId = 15, SpecialDetails = "Villa 15 - Room 2" },
        new VillaNumber { Villa_Number = 1503, VillaId = 15, SpecialDetails = "Villa 15 - Room 3" },

        // Villa 16
        new VillaNumber { Villa_Number = 1601, VillaId = 16, SpecialDetails = "Villa 16 - Room 1" },
        new VillaNumber { Villa_Number = 1602, VillaId = 16, SpecialDetails = "Villa 16 - Room 2" },
        new VillaNumber { Villa_Number = 1603, VillaId = 16, SpecialDetails = "Villa 16 - Room 3" },

        // Villa 19
        new VillaNumber { Villa_Number = 1901, VillaId = 19, SpecialDetails = "Villa 19 - Room 1" },
        new VillaNumber { Villa_Number = 1902, VillaId = 19, SpecialDetails = "Villa 19 - Room 2" },
        new VillaNumber { Villa_Number = 1903, VillaId = 19, SpecialDetails = "Villa 19 - Room 3" }

            };
        }
    }
}
