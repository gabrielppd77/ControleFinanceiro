using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class DropClassificationTableAndYourReleation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_financial_entries_classifications_classification_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropTable(
                name: "classifications",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "ix_financial_entries_classification_id",
                schema: "public",
                table: "financial_entries");

            migrationBuilder.DropColumn(
                name: "classification_id",
                schema: "public",
                table: "financial_entries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "classification_id",
                schema: "public",
                table: "financial_entries",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "classifications",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_classifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_classifications_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_financial_entries_classification_id",
                schema: "public",
                table: "financial_entries",
                column: "classification_id");

            migrationBuilder.CreateIndex(
                name: "ix_classifications_user_id",
                schema: "public",
                table: "classifications",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_financial_entries_classifications_classification_id",
                schema: "public",
                table: "financial_entries",
                column: "classification_id",
                principalSchema: "public",
                principalTable: "classifications",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
