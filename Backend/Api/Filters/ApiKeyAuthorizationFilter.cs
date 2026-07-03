using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters;

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private const string ApiKeyHeader = "X-Api-Key";

    private readonly IConfiguration _configuration;

    public ApiKeyAuthorizationFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var requestApiKey = context.HttpContext.Request.Headers[ApiKeyHeader].FirstOrDefault();
        var configuredApiKey = _configuration["ApiKeySettings:Key"];

        if (string.IsNullOrEmpty(requestApiKey) || requestApiKey != configuredApiKey)
            context.Result = new UnauthorizedResult();
    }
}
