using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class ChangedConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_AspNetUsers_ViolatorId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_ViolatorId",
                table: "Violations");

            migrationBuilder.DropColumn(
                name: "ViolatorId",
                table: "Violations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Violations",
                nullable: false,
                oldClrType: typeof(string));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Violations_AspNetUsers_UserId",
                table: "Violations");

            migrationBuilder.DropIndex(
                name: "IX_Violations_UserId",
                table: "Violations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Violations",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ViolatorId",
                table: "Violations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Violations_ViolatorId",
                table: "Violations",
                column: "ViolatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Violations_AspNetUsers_ViolatorId",
                table: "Violations",
                column: "ViolatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
