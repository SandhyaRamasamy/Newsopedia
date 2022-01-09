using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsopedia.Data.Migrations.NewsopediaOld
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetTopUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JunctionUserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetTopUsers", x => x.UserId);
                });
        }

            
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetTopUsers");

            migrationBuilder.DropTable(
                name: "User_NewsTable");

            migrationBuilder.DropTable(
                name: "NewsTable");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
