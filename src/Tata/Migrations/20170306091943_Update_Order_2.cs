using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tata.Migrations
{
    public partial class Update_Order_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Billings_BillingId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingId",
                table: "Orders",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Billings_BillingId",
                table: "Orders",
                column: "BillingId",
                principalTable: "Billings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
