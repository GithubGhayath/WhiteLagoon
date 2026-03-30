using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class maketablestatusgloabaltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_PaymentStatues_PaymentStatusId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentStatues");

            migrationBuilder.RenameColumn(
                name: "PaymentStatusId",
                table: "Payments",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_PaymentStatusId",
                table: "Payments",
                newName: "IX_Payments_StatusId");

            migrationBuilder.CreateTable(
                name: "Statues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statues", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Statues_StatusId",
                table: "Payments",
                column: "StatusId",
                principalTable: "Statues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Statues_StatusId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Statues");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Payments",
                newName: "PaymentStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_StatusId",
                table: "Payments",
                newName: "IX_Payments_PaymentStatusId");

            migrationBuilder.CreateTable(
                name: "PaymentStatues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatues", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_PaymentStatues_PaymentStatusId",
                table: "Payments",
                column: "PaymentStatusId",
                principalTable: "PaymentStatues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
