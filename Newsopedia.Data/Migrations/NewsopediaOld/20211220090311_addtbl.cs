using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsopedia.Data.Migrations.NewsopediaOld
{
    public partial class addtbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetTopUsers",
                columns: table => new
                {
                 
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                }); ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetTopUsers");
        }
    }
}
