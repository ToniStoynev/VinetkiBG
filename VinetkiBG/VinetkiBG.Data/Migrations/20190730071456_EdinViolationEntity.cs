using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class EdinViolationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_UserId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Violations");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Violations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_UserId",
                table: "Violations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
