using Api.Configurations.GlobalException;
using Api.CorsPolicies;

namespace Api;

public static class DependencyInjection
{
    public static void AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddCorsPolicy(configuration);
    }

    private static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        var corsSettings = new CorsSettings();
        configuration.Bind(CorsSettings.SectionName, corsSettings);

        var allowedOrigins = corsSettings.AllowedOrigins.Split(";");

        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicy.Default, policy =>
            {
                policy.WithOrigins(allowedOrigins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }

    public static void UseApi(this WebApplication app)
    {
        app.UseExceptionHandler();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseCors(CorsPolicy.Default);
    }
}
