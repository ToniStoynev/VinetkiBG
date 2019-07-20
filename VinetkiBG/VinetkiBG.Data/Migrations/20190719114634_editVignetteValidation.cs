using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class editVignetteValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Caterory",
                table: "Vignettes",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Caterory",
                table: "Vignettes",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
