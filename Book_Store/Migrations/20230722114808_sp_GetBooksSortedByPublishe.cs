using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class sp_GetBooksSortedByPublishe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE sp_GetBooksSortedByPublisher
                                    AS
                                    BEGIN
                                    SET NOCOUNT ON
                                        SELECT *  
                                        FROM Books
                                        ORDER BY AuthorLastName,AuthorFirstName,Title ASC
                                    END";
            migrationBuilder.Sql(procedure);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE sp_GetBooksSortedByPublisher";
            migrationBuilder.Sql(procedure);
        }
    }
}
