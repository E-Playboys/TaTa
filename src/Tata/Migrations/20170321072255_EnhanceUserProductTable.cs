using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tata.Migrations
{
    public partial class EnhanceUserProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAdress",
                table: "UserProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "UserProducts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserProducts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VpsUsername",
                table: "UserProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProductId",
                table: "ProductProperties",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_UserProductId",
                table: "ProductProperties",
                column: "UserProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_UserProducts_UserProductId",
                table: "ProductProperties",
                column: "UserProductId",
                principalTable: "UserProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_UserProducts_UserProductId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_UserProductId",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "IpAdress",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "VpsUsername",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "UserProductId",
                table: "ProductProperties");
        }
    }
}
