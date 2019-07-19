using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class EditedVignette : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Vignettes");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Vignettes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Vignettes");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Vignettes",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CVV = table.Column<string>(maxLength: 3, nullable: false),
                    CardHolderName = table.Column<string>(maxLength: 20, nullable: false),
                    CreditCardNumber = table.Column<string>(maxLength: 12, nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_OwnerId",
                table: "CreditCards",
                column: "OwnerId");
        }
    }
}
