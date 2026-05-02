using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ConvertFieldClassificationIdInClassificationEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE financial_entries fe
                SET ""classification"" = CASE
                    WHEN c.""name"" = 'Despesa' THEN 0
                    WHEN c.""name"" = 'Receita' THEN 1
                    ELSE NULL
                END
                FROM classifications c
                WHERE fe.classification_id = c.""id"";
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE financial_entries
                SET ""classification"" = NULL;
            ");
        }
    }
}
