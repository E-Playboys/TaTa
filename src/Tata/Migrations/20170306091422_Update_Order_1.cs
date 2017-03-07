using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tata.Migrations
{
    public partial class Update_Order_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductPrices_ProductPriceId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ProductPriceId",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductPriceId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderItems",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GrossTotal",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "Orders",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "GrossTotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "ProductPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductPrices_ProductPriceId",
                table: "OrderItems",
                column: "ProductPriceId",
                principalTable: "ProductPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
