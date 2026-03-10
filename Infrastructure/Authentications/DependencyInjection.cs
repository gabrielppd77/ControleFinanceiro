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
        var jwtSettings = configuration
            .GetRequiredSection(JwtSettings.SectionName)
            .Get<JwtSettings>()!;

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();

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
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Token inválido: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },

                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Autenticado: " + context.Principal.Identity.IsAuthenticated);
                        Console.WriteLine("Claims:");

                        foreach (var claim in context.Principal.Claims)
                        {
                            Console.WriteLine($"{claim.Type} : {claim.Value}");
                        }
                        return Task.CompletedTask;
                    },

                    OnChallenge = context =>
                    {
                        Console.WriteLine("Challenge error: " + context.Error);
                        Console.WriteLine("Description: " + context.ErrorDescription);
                        return Task.CompletedTask;
                    }

                    //OnChallenge = async context =>
                    //{
                    //    context.HandleResponse();

                    //    var problemDetails = new ProblemDetails
                    //    {
                    //        Status = StatusCodes.Status401Unauthorized,
                    //        Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                    //        Title = "Authentication failed",
                    //        Detail = context.ErrorDescription,
                    //    };
                    //    context.Response.StatusCode = problemDetails.Status.Value;
                    //    context.Response.ContentType = "application/json";
                    //    context.Response.Headers["Access-Control-Allow-Origin"] = "*";

                    //    await context.Response.WriteAsJsonAsync(problemDetails);
                    //},
                };
            });

        return services;
    }
}