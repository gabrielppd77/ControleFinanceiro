using Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class InfrastructureExtensions
{
    public static void UseInfrastructure(this WebApplication app)
    {
        app.UseApplyMigrations();
    }

    public static void UseApplyMigrations(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using IServiceScope scope = app.Services.CreateScope();

            using ApplicationDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
