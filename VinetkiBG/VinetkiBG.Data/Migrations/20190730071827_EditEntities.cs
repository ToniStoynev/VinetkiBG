using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class EditEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_AspNetUsers_VinetkiBGUserId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_VinetkiBGUserId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "VinetkiBGUserId",
                table: "Violations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VinetkiBGUserId",
                table: "Violations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Violations_VinetkiBGUserId",
                table: "Violations",
                column: "VinetkiBGUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_AspNetUsers_VinetkiBGUserId",
                table: "Violations",
                column: "VinetkiBGUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
