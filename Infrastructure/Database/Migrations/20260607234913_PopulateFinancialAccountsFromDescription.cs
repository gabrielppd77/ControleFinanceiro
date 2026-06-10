using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class PopulateFinancialAccountsFromDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                -- Cria uma conta por combinação de usuário + nome da conta
                INSERT INTO financial_accounts (id, user_id, name, created_at)
                SELECT
                    gen_random_uuid(),
                    x.user_id,
                    x.account_name,
                    now()
                FROM (
                    SELECT DISTINCT
                        user_id,
                        trim(split_part(description, ' - ', 1)) AS account_name
                    FROM financial_entries
                    WHERE description IS NOT NULL
                      AND position(' - ' in description) > 0
                ) x
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM financial_accounts fa
                    WHERE fa.user_id = x.user_id
                      AND fa.name = x.account_name
                );

                -- Vincula os lançamentos às contas criadas/encontradas
                UPDATE financial_entries fe
                SET account_id = fa.id
                FROM financial_accounts fa
                WHERE fa.user_id = fe.user_id
                  AND fa.name = trim(split_part(fe.description, ' - ', 1))
                  AND position(' - ' in fe.description) > 0;

                -- Remove o nome da conta da descrição
                UPDATE financial_entries
                SET description = substring(
                    description
                    FROM position(' - ' in description) + 3
                )
                WHERE position(' - ' in description) > 0;
            """);
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                -- Reconstrói a descrição original
                UPDATE financial_entries fe
                SET description = fa.name || ' - ' || fe.description
                FROM financial_accounts fa
                WHERE fe.account_id = fa.id;

                -- Remove o vínculo
                UPDATE financial_entries
                SET account_id = NULL;

                -- Remove contas sem uso
                DELETE FROM financial_accounts fa
                WHERE NOT EXISTS (
                    SELECT 1
                    FROM financial_entries fe
                    WHERE fe.account_id = fa.id
                );
            """);
        }
    }
}
