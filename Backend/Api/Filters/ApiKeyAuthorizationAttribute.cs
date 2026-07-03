using Microsoft.AspNetCore.Mvc;

namespace Api.Filters;

public class ApiKeyAuthorizationAttribute : ServiceFilterAttribute
{
    public ApiKeyAuthorizationAttribute() : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}
