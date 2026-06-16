using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""users"" SET ""created_at"" = NOW()");
            migrationBuilder.Sql(@"UPDATE ""financial_types"" SET ""created_at"" = NOW()");
            migrationBuilder.Sql(@"UPDATE ""financial_entries"" SET ""created_at"" = NOW()");
            migrationBuilder.Sql(@"UPDATE ""classifications"" SET ""created_at"" = NOW()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE ""users"" SET ""created_at"" = NULL");
            migrationBuilder.Sql(@"UPDATE ""financial_types"" SET ""created_at"" = NULL");
            migrationBuilder.Sql(@"UPDATE ""financial_entries"" SET ""created_at"" = NULL");
            migrationBuilder.Sql(@"UPDATE ""classifications"" SET ""created_at"" = NULL");
        }
    }
}
