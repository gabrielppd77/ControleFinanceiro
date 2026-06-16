using Infrastructure.Authentications;
using Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuth(configuration);
        services.AddDatabase(configuration);
        services.AddRepositories();
    }
}
