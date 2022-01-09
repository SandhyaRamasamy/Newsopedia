using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsopedia.Data.Migrations
{
    public partial class updateddateurltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsDescription",
                table: "DateUrls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewsImageURL",
                table: "DateUrls",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsDescription",
                table: "DateUrls");

            migrationBuilder.DropColumn(
                name: "NewsImageURL",
                table: "DateUrls");
        }
    }
}
