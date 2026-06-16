using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Contracts.Authentications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentications;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IUserAuthenticated, UserAuthenticated>();

        var jwtSettings = configuration
            .GetRequiredSection(JwtSettings.SectionName)
            .Get<JwtSettings>()!;

        services.AddSingleton(Options.Create(jwtSettings));

        services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    NameClaimType = JwtRegisteredClaimNames.Name
                };
                x.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        var problemDetails = new ProblemDetails
                        {
                            Status = StatusCodes.Status401Unauthorized,
                            Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                            Title = "Authentication failed",
                            Detail = context.ErrorDescription,
                        };
                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/json";
                        context.Response.Headers["Access-Control-Allow-Origin"] = "*";

                        await context.Response.WriteAsJsonAsync(problemDetails);
                    },
                };
            });

        return services;
    }
}