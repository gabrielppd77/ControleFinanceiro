using Api.Controllers.Base;
using Application.Authentications.Common;
using Application.Authentications.CreateUser;
using Application.Authentications.LoginUser;
using Application.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]/[action]")]
public class AuthenticationsController : ApiController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(IServiceHandler<CreateUserRequest, AuthenticationResponse> service, CreateUserRequest request)
    {
        var response = await service.Handle(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login(IServiceHandler<LoginUserRequest, AuthenticationResponse> service, LoginUserRequest request)
    {
        var response = await service.Handle(request);
        return Ok(response);
    }
}
