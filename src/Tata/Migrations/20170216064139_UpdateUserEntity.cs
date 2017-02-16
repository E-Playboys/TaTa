using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tata.Migrations
{
    public partial class UpdateUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_ApplicationUser_ApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_ApplicationUser_ApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_ApplicationUser_ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Billings_ApplicationUser_CreatedUserId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ApplicationUser_CreatedUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ApplicationUser_CreatedUserId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ApplicationUser_CreatedUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ApplicationUser_CreatedUserId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_ApplicationUser_CreatedUserId",
                table: "ProductPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_ApplicationUser_CreatedUserId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_ApplicationUser_CreatedUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_ApplicationUser_CreatedUserId",
                table: "UserProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_ApplicationUser_UserId",
                table: "UserProducts");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_ApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_ApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "AspNetUserClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Settings",
                type: "ntext",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_AspNetUsers_CreatedUserId",
                table: "Billings",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedUserId",
                table: "Orders",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_AspNetUsers_CreatedUserId",
                table: "OrderItems",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedUserId",
                table: "Products",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_AspNetUsers_CreatedUserId",
                table: "ProductCategories",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_AspNetUsers_CreatedUserId",
                table: "ProductPrices",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_AspNetUsers_CreatedUserId",
                table: "ProductProperties",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AspNetUsers_CreatedUserId",
                table: "Settings",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_AspNetUsers_CreatedUserId",
                table: "UserProducts",
                column: "CreatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_AspNetUsers_UserId",
                table: "UserProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billings_AspNetUsers_CreatedUserId",
                table: "Billings");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_AspNetUsers_CreatedUserId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_AspNetUsers_CreatedUserId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrices_AspNetUsers_CreatedUserId",
                table: "ProductPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_AspNetUsers_CreatedUserId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AspNetUsers_CreatedUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_AspNetUsers_CreatedUserId",
                table: "UserProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_AspNetUsers_UserId",
                table: "UserProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUserRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUserLogins",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "AspNetUserClaims",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_ApplicationUserId",
                table: "AspNetUserLogins",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_ApplicationUserId",
                table: "AspNetUserClaims",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_ApplicationUser_ApplicationUserId",
                table: "AspNetUserClaims",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_ApplicationUser_ApplicationUserId",
                table: "AspNetUserLogins",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_ApplicationUser_ApplicationUserId",
                table: "AspNetUserRoles",
                column: "ApplicationUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Billings_ApplicationUser_CreatedUserId",
                table: "Billings",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ApplicationUser_CreatedUserId",
                table: "Orders",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ApplicationUser_CreatedUserId",
                table: "OrderItems",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ApplicationUser_CreatedUserId",
                table: "Products",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ApplicationUser_CreatedUserId",
                table: "ProductCategories",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrices_ApplicationUser_CreatedUserId",
                table: "ProductPrices",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_ApplicationUser_CreatedUserId",
                table: "ProductProperties",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_ApplicationUser_CreatedUserId",
                table: "Settings",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_ApplicationUser_CreatedUserId",
                table: "UserProducts",
                column: "CreatedUserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_ApplicationUser_UserId",
                table: "UserProducts",
                column: "UserId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
