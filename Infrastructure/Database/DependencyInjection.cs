using Contracts.Repositories;
using Contracts.Repositories.Classifications;
using Contracts.Repositories.FinancialEntries;
using Contracts.Repositories.FinancialTypes;
using Contracts.Repositories.Users;
using Infrastructure.Database.Context;
using Infrastructure.Database.Repositories;
using Infrastructure.Database.Repositories.Classifications;
using Infrastructure.Database.Repositories.FinancialEntries;
using Infrastructure.Database.Repositories.FinancialTypes;
using Infrastructure.Database.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database;

public static class DependencyInjection
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(
            options => options
                .UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
                .UseSnakeCaseNamingConvention());
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IClassificationRepository, ClassificationRepository>();
        services.AddScoped<IFinancialTypeRepository, FinancialTypeRepository>();
        services.AddScoped<IFinancialEntryRepository, FinancialEntryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
