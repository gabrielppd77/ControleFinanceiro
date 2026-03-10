using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationUserWithFinancialTypesClassificationsAndFinancialEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "public",
                table: "financial_types",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "public",
                table: "financial_entries",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                schema: "public",
                table: "classifications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_financial_types_user_id",
                schema: "public",
                table: "financial_types",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_financial_entries_user_id",
                schema: "public",
                table: "financial_entries",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_classifications_user_id",
                schema: "public",
                table: "classifications",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_classifications_users_user_id",
                schema: "public",
                table: "classifications",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_financial_entries_users_user_id",
                schema: "public",
                table: "financial_entries",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_financial_types_users_user_id",
                schema: "public",
                table: "financial_types",
                column: "user_id",
                principalSchema: "public",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_classifications_users_user_id",
                schema: "public",
                table: "classifications");

            migrationBuilder.DropForeignKey(
                name: "fk_financial_entries_users_user_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropForeignKey(
                name: "fk_financial_types_users_user_id",
                schema: "public",
                table: "financial_types");

            migrationBuilder.DropIndex(
                name: "ix_financial_types_user_id",
                schema: "public",
                table: "financial_types");

            migrationBuilder.DropIndex(
                name: "ix_financial_entries_user_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropIndex(
                name: "ix_classifications_user_id",
                schema: "public",
                table: "classifications");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "public",
                table: "financial_types");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropColumn(
                name: "user_id",
                schema: "public",
                table: "classifications");
        }
    }
}
