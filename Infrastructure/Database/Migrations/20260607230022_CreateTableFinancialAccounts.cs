using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableFinancialAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "account_id",
                schema: "public",
                table: "financial_entries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "financial_accounts",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financial_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_financial_accounts_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_financial_entries_account_id",
                schema: "public",
                table: "financial_entries",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_financial_accounts_user_id",
                schema: "public",
                table: "financial_accounts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_financial_entries_financial_accounts_account_id",
                schema: "public",
                table: "financial_entries",
                column: "account_id",
                principalSchema: "public",
                principalTable: "financial_accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_financial_entries_financial_accounts_account_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropTable(
                name: "financial_accounts",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_financial_entries_account_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropColumn(
                name: "account_id",
                schema: "public",
                table: "financial_entries");
        }
    }
}
