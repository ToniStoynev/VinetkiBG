using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class ViolationEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ViolationType = table.Column<string>(nullable: false),
                    PenaltyAmount = table.Column<decimal>(nullable: false),
                    VehicleId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ViolatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Violations_Vechiles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vechiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Violations_AspNetUsers_ViolatorId",
                        column: x => x.ViolatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Violations_VehicleId",
                table: "Violations",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_ViolatorId",
                table: "Violations",
                column: "ViolatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Violations");
        }
    }
}
