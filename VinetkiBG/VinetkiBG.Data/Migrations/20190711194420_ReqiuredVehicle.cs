using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class ReqiuredVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vignettes_Vechiles_VechileId",
                table: "Vignettes");

            migrationBuilder.DropIndex(
                name: "IX_Vignettes_VechileId",
                table: "Vignettes");

            migrationBuilder.AlterColumn<string>(
                name: "VechileId",
                table: "Vignettes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vignettes_VechileId",
                table: "Vignettes",
                column: "VechileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vignettes_Vechiles_VechileId",
                table: "Vignettes",
                column: "VechileId",
                principalTable: "Vechiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vignettes_Vechiles_VechileId",
                table: "Vignettes");

            migrationBuilder.DropIndex(
                name: "IX_Vignettes_VechileId",
                table: "Vignettes");

            migrationBuilder.AlterColumn<string>(
                name: "VechileId",
                table: "Vignettes",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Vignettes_VechileId",
                table: "Vignettes",
                column: "VechileId",
                unique: true,
                filter: "[VechileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vignettes_Vechiles_VechileId",
                table: "Vignettes",
                column: "VechileId",
                principalTable: "Vechiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
