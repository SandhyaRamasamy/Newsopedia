using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsopedia.Data.Migrations
{
    public partial class includedTitleField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsTitle",
                table: "DateUrls",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsTitle",
                table: "DateUrls");
        }
    }
}
