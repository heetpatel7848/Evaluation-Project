using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalTask.Models.Migrations
{
    /// <inheritdoc />
    public partial class PriceChangeAddedWholeAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceChanges",
                columns: table => new
                {
                    Srno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    OldCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Increase_Decrease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceUpdate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewCost = table.Column<int>(type: "int", nullable: false),
                    OldPrice = table.Column<int>(type: "int", nullable: false),
                    NewPrice = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceChanges", x => x.Srno);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceChanges");
        }
    }
}
