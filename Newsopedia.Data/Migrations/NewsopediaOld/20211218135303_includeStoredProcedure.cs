using Microsoft.EntityFrameworkCore.Migrations;

namespace Newsopedia.Data.Migrations.NewsopediaOld
{
    public partial class includeStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create procedure SPGetTopFiveUsers
                                    As
                                    Begin
                                    select top 3 FirstName from 
                                    (select x.UserId,x.total, FirstName, LastName from 
                                    (select t1.UserId,
                                        count(*) total
                                     from [NewsopediaOld].[dbo].[User_NewsTable] t1 
                                    Group By t1.UserId)
                                    as x inner join  [NewsopediaOld].[dbo].[User] t2
                                    on x.UserId=t2.UserId) res
                                    order By res.total desc
                                    END";
            migrationBuilder.Sql(procedure);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"drop procedure SPGetTopFiveUsers";

            migrationBuilder.Sql(procedure);
        }
    }
}
