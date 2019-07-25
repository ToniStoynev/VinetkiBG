using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class VehicleViolation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Violations_VehicleId",
                table: "Violations");

            migrationBuilder.AddColumn<string>(
                name: "ViolationId",
                table: "Vechiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Violations_VehicleId",
                table: "Violations",
                column: "VehicleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Violations_VehicleId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "ViolationId",
                table: "Vechiles");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_VehicleId",
                table: "Violations",
                column: "VehicleId");
        }
    }
}
