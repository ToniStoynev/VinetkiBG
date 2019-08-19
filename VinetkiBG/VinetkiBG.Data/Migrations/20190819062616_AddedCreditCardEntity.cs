using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinetkiBG.Data.Migrations
{
    public partial class AddedCreditCardEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        UserName = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
            //        Email = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(nullable: false),
            //        PasswordHash = table.Column<string>(nullable: true),
            //        SecurityStamp = table.Column<string>(nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true),
            //        PhoneNumber = table.Column<string>(nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
            //        LockoutEnabled = table.Column<bool>(nullable: false),
            //        AccessFailedCount = table.Column<int>(nullable: false),
            //        FirstName = table.Column<string>(nullable: true),
            //        LastName = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        RoleId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(nullable: false),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(nullable: false),
            //        ProviderKey = table.Column<string>(nullable: false),
            //        ProviderDisplayName = table.Column<string>(nullable: true),
            //        UserId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        RoleId = table.Column<string>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(nullable: false),
            //        Value = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BankName = table.Column<string>(nullable: false),
                    IBAN = table.Column<string>(nullable: false),
                    BIC = table.Column<string>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    CardHolderId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_AspNetUsers_CardHolderId",
                        column: x => x.CardHolderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        //    migrationBuilder.CreateTable(
        //        name: "Vehicles",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            Brand = table.Column<string>(maxLength: 12, nullable: false),
        //            Country = table.Column<string>(maxLength: 20, nullable: false),
        //            PlateNumber = table.Column<string>(maxLength: 10, nullable: false),
        //            Type = table.Column<string>(maxLength: 20, nullable: false),
        //            OwnerId = table.Column<string>(nullable: true),
        //            VignetteId = table.Column<string>(nullable: true),
        //            ViolationId = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Vehicles", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_Vehicles_AspNetUsers_OwnerId",
        //                column: x => x.OwnerId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

            //    migrationBuilder.CreateTable(
            //        name: "Vignettes",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(nullable: false),
            //            Category = table.Column<string>(nullable: false),
            //            Price = table.Column<decimal>(nullable: false),
            //            StartDate = table.Column<DateTime>(nullable: false),
            //            EndDate = table.Column<DateTime>(nullable: false),
            //            VehicleId = table.Column<string>(nullable: false),
            //            RecipietId = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Vignettes", x => x.Id);
            //            table.ForeignKey(
            //                name: "FK_Vignettes_Vehicles_VehicleId",
            //                column: x => x.VehicleId,
            //                principalTable: "Vehicles",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "Violations",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(nullable: false),
            //            ViolationType = table.Column<string>(nullable: false),
            //            Road = table.Column<string>(nullable: false),
            //            ViolationDate = table.Column<DateTime>(nullable: false),
            //            PenaltyAmount = table.Column<decimal>(nullable: false),
            //            VehicleId = table.Column<string>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Violations", x => x.Id);
            //            table.ForeignKey(
            //                name: "FK_Violations_Vehicles_VehicleId",
            //                column: x => x.VehicleId,
            //                principalTable: "Vehicles",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "Receipts",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(nullable: false),
            //            LicensePlate = table.Column<string>(nullable: false),
            //            VehicleType = table.Column<string>(nullable: false),
            //            StartDate = table.Column<DateTime>(nullable: false),
            //            EndDate = table.Column<DateTime>(nullable: false),
            //            Price = table.Column<decimal>(nullable: false),
            //            VignetteId = table.Column<string>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_Receipts", x => x.Id);
            //            table.ForeignKey(
            //                name: "FK_Receipts_Vignettes_VignetteId",
            //                column: x => x.VignetteId,
            //                principalTable: "Vignettes",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Cascade);
            //        });

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetRoleClaims_RoleId",
            //        table: "AspNetRoleClaims",
            //        column: "RoleId");

            //    migrationBuilder.CreateIndex(
            //        name: "RoleNameIndex",
            //        table: "AspNetRoles",
            //        column: "NormalizedName",
            //        unique: true,
            //        filter: "[NormalizedName] IS NOT NULL");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetUserClaims_UserId",
            //        table: "AspNetUserClaims",
            //        column: "UserId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetUserLogins_UserId",
            //        table: "AspNetUserLogins",
            //        column: "UserId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_AspNetUserRoles_RoleId",
            //        table: "AspNetUserRoles",
            //        column: "RoleId");

            //    migrationBuilder.CreateIndex(
            //        name: "EmailIndex",
            //        table: "AspNetUsers",
            //        column: "NormalizedEmail");

            //    migrationBuilder.CreateIndex(
            //        name: "UserNameIndex",
            //        table: "AspNetUsers",
            //        column: "NormalizedUserName",
            //        unique: true,
            //        filter: "[NormalizedUserName] IS NOT NULL");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_CreditCards_CardHolderId",
            //        table: "CreditCards",
            //        column: "CardHolderId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Receipts_VignetteId",
            //        table: "Receipts",
            //        column: "VignetteId",
            //        unique: true);

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Vehicles_OwnerId",
            //        table: "Vehicles",
            //        column: "OwnerId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Vignettes_VehicleId",
            //        table: "Vignettes",
            //        column: "VehicleId",
            //        unique: true);

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Violations_VehicleId",
            //        table: "Violations",
            //        column: "VehicleId",
            //        unique: true);
            //}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Vignettes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
