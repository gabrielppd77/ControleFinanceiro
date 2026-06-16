using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTableRecurringEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recurring_entries",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    classification = table.Column<int>(type: "integer", nullable: false),
                    day_of_month = table.Column<int>(type: "integer", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    account_id = table.Column<Guid>(type: "uuid", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recurring_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_recurring_entries_financial_accounts_account_id",
                        column: x => x.account_id,
                        principalSchema: "public",
                        principalTable: "financial_accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recurring_entries_financial_types_type_id",
                        column: x => x.type_id,
                        principalSchema: "public",
                        principalTable: "financial_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recurring_entries_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recurring_entry_occurrences",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    recurring_entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    financial_entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    occurrence_date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recurring_entry_occurrences", x => x.id);
                    table.ForeignKey(
                        name: "fk_recurring_entry_occurrences_financial_entries_financial_ent",
                        column: x => x.financial_entry_id,
                        principalSchema: "public",
                        principalTable: "financial_entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_recurring_entry_occurrences_recurring_entries_recurring_ent",
                        column: x => x.recurring_entry_id,
                        principalSchema: "public",
                        principalTable: "recurring_entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_recurring_entries_account_id",
                schema: "public",
                table: "recurring_entries",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "ix_recurring_entries_type_id",
                schema: "public",
                table: "recurring_entries",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_recurring_entries_user_id",
                schema: "public",
                table: "recurring_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_recurring_entry_occurrences_financial_entry_id",
                schema: "public",
                table: "recurring_entry_occurrences",
                column: "financial_entry_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_recurring_entry_occurrences_recurring_entry_id",
                schema: "public",
                table: "recurring_entry_occurrences",
                column: "recurring_entry_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recurring_entry_occurrences",
                schema: "public");

            migrationBuilder.DropTable(
                name: "recurring_entries",
                schema: "public");
        }
    }
}
