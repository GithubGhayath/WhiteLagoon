using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingVillaNumbersEntityWithCongirurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumber",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumber", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumber_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VillaNumber",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, "Villa 1 - Room 1", 1 },
                    { 102, "Villa 1 - Room 2", 1 },
                    { 103, "Villa 1 - Room 3", 1 },
                    { 201, "Villa 2 - Room 1", 2 },
                    { 202, "Villa 2 - Room 2", 2 },
                    { 203, "Villa 2 - Room 3", 2 },
                    { 301, "Villa 3 - Room 1", 3 },
                    { 302, "Villa 3 - Room 2", 3 },
                    { 303, "Villa 3 - Room 3", 3 },
                    { 401, "Villa 4 - Room 1", 4 },
                    { 402, "Villa 4 - Room 2", 4 },
                    { 403, "Villa 4 - Room 3", 4 },
                    { 501, "Villa 5 - Room 1", 5 },
                    { 502, "Villa 5 - Room 2", 5 },
                    { 503, "Villa 5 - Room 3", 5 },
                    { 601, "Villa 6 - Room 1", 6 },
                    { 602, "Villa 6 - Room 2", 6 },
                    { 603, "Villa 6 - Room 3", 6 },
                    { 701, "Villa 7 - Room 1", 7 },
                    { 702, "Villa 7 - Room 2", 7 },
                    { 703, "Villa 7 - Room 3", 7 },
                    { 801, "Villa 8 - Room 1", 8 },
                    { 802, "Villa 8 - Room 2", 8 },
                    { 803, "Villa 8 - Room 3", 8 },
                    { 901, "Villa 9 - Room 1", 9 },
                    { 902, "Villa 9 - Room 2", 9 },
                    { 903, "Villa 9 - Room 3", 9 },
                    { 1001, "Villa 10 - Room 1", 10 },
                    { 1002, "Villa 10 - Room 2", 10 },
                    { 1003, "Villa 10 - Room 3", 10 },
                    { 1101, "Villa 11 - Room 1", 11 },
                    { 1102, "Villa 11 - Room 2", 11 },
                    { 1103, "Villa 11 - Room 3", 11 },
                    { 1201, "Villa 12 - Room 1", 12 },
                    { 1202, "Villa 12 - Room 2", 12 },
                    { 1203, "Villa 12 - Room 3", 12 },
                    { 1301, "Villa 13 - Room 1", 13 },
                    { 1302, "Villa 13 - Room 2", 13 },
                    { 1303, "Villa 13 - Room 3", 13 },
                    { 1401, "Villa 14 - Room 1", 14 },
                    { 1402, "Villa 14 - Room 2", 14 },
                    { 1403, "Villa 14 - Room 3", 14 },
                    { 1501, "Villa 15 - Room 1", 15 },
                    { 1502, "Villa 15 - Room 2", 15 },
                    { 1503, "Villa 15 - Room 3", 15 },
                    { 1601, "Villa 16 - Room 1", 16 },
                    { 1602, "Villa 16 - Room 2", 16 },
                    { 1603, "Villa 16 - Room 3", 16 },
                    { 1901, "Villa 19 - Room 1", 19 },
                    { 1902, "Villa 19 - Room 2", 19 },
                    { 1903, "Villa 19 - Room 3", 19 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumber_VillaId",
                table: "VillaNumber",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumber");
        }
    }
}
