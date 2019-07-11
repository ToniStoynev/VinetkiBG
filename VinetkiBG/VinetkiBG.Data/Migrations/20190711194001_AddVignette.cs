using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class AddVignette : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vignettes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Caterory = table.Column<string>(maxLength: 2, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Duration = table.Column<string>(maxLength: 15, nullable: false),
                    VechileId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vignettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vignettes_Vechiles_VechileId",
                        column: x => x.VechileId,
                        principalTable: "Vechiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vignettes_VechileId",
                table: "Vignettes",
                column: "VechileId",
                unique: true,
                filter: "[VechileId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vignettes");
        }
    }
}
