using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFuel.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Fuel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Fuel_id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Price_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceValue = table.Column<double>(type: "float", nullable: true),
                    Fuel_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Price_id);
                });

            migrationBuilder.CreateTable(
                name: "Refill",
                columns: table => new
                {
                    Refill_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuel_id = table.Column<int>(type: "int", nullable: false),
                    FuelTypeFuel_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refill", x => x.Refill_id);
                    table.ForeignKey(
                        name: "FK_Refill_FuelType_FuelTypeFuel_id",
                        column: x => x.FuelTypeFuel_id,
                        principalTable: "FuelType",
                        principalColumn: "Fuel_id");
                });

            migrationBuilder.CreateTable(
                name: "JournalLine",
                columns: table => new
                {
                    Line_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Refill_id = table.Column<int>(type: "int", nullable: false),
                    BaleRefill_id = table.Column<int>(type: "int", nullable: true),
                    FuelTypeFuel_id = table.Column<int>(type: "int", nullable: true),
                    Price_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalLine", x => x.Line_id);
                    table.ForeignKey(
                        name: "FK_JournalLine_FuelType_FuelTypeFuel_id",
                        column: x => x.FuelTypeFuel_id,
                        principalTable: "FuelType",
                        principalColumn: "Fuel_id");
                    table.ForeignKey(
                        name: "FK_JournalLine_Price_Price_id",
                        column: x => x.Price_id,
                        principalTable: "Price",
                        principalColumn: "Price_id");
                    table.ForeignKey(
                        name: "FK_JournalLine_Refill_BaleRefill_id",
                        column: x => x.BaleRefill_id,
                        principalTable: "Refill",
                        principalColumn: "Refill_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalLine_BaleRefill_id",
                table: "JournalLine",
                column: "BaleRefill_id");

            migrationBuilder.CreateIndex(
                name: "IX_JournalLine_FuelTypeFuel_id",
                table: "JournalLine",
                column: "FuelTypeFuel_id");

            migrationBuilder.CreateIndex(
                name: "IX_JournalLine_Price_id",
                table: "JournalLine",
                column: "Price_id");

            migrationBuilder.CreateIndex(
                name: "IX_Refill_FuelTypeFuel_id",
                table: "Refill",
                column: "FuelTypeFuel_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalLine");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "Refill");

            migrationBuilder.DropTable(
                name: "FuelType");
        }
    }
}
