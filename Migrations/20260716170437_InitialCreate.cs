using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OriginCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OriginAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DestinationCity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DestinationAddress = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
