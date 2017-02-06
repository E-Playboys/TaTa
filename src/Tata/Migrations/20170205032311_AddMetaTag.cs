using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tata.Migrations
{
    public partial class AddMetaTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaTagDescription",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTagKeywords",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTagTitle",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaTagDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaTagKeywords",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaTagTitle",
                table: "Products");
        }
    }
}
