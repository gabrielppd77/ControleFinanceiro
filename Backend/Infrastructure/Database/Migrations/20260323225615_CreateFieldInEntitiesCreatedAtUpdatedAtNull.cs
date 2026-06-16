using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateFieldInEntitiesCreatedAtUpdatedAtNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "financial_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "financial_types",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "financial_entries",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "financial_entries",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                schema: "public",
                table: "classifications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                schema: "public",
                table: "classifications",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "public",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "financial_types");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "public",
                table: "financial_types");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropColumn(
                name: "created_at",
                schema: "public",
                table: "classifications");

            migrationBuilder.DropColumn(
                name: "updated_at",
                schema: "public",
                table: "classifications");
        }
    }
}
