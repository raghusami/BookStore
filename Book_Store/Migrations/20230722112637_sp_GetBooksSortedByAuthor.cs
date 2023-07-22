using Microsoft.EntityFrameworkCore.Migrations;

namespace Book_Store.Migrations
{
    public partial class sp_GetBooksSortedByAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"CREATE PROCEDURE sp_GetBooksSortedByAuthor
                                    AS
                                    BEGIN
                                    SET NOCOUNT ON
                                        SELECT *  
                                        FROM Books
                                        ORDER BY  Publisher,AuthorLastName,AuthorFirstName,Title ASC
                                    END";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP PROCEDURE sp_GetBooksSortedByAuthor";
            migrationBuilder.Sql(procedure);
        }
    }
}
