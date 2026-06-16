using System.Security.Claims;
using Contracts.Authentications;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Authentications;

public class UserAuthenticated : IUserAuthenticated
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAuthenticated(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var userIdentifier = _httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(userIdentifier, out var userId) ? userId : Guid.Empty;
    }
}