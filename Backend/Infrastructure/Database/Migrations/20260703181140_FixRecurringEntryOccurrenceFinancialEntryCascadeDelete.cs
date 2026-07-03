using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixRecurringEntryOccurrenceFinancialEntryCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_recurring_entry_occurrences_financial_entries_financial_ent",
                schema: "public",
                table: "recurring_entry_occurrences");

            migrationBuilder.AddForeignKey(
                name: "fk_recurring_entry_occurrences_financial_entries_financial_ent",
                schema: "public",
                table: "recurring_entry_occurrences",
                column: "financial_entry_id",
                principalSchema: "public",
                principalTable: "financial_entries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_recurring_entry_occurrences_financial_entries_financial_ent",
                schema: "public",
                table: "recurring_entry_occurrences");

            migrationBuilder.AddForeignKey(
                name: "fk_recurring_entry_occurrences_financial_entries_financial_ent",
                schema: "public",
                table: "recurring_entry_occurrences",
                column: "financial_entry_id",
                principalSchema: "public",
                principalTable: "financial_entries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
