using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkCore.Migrations
{
    public partial class addedstoredprocedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[GetCategories]
                @Name varchar(200)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT * FROM Categories
                    WHERE [Name] = @Name
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetCategories]");
        }
    }
}
