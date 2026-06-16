using Api.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
[Route("")]
public class ProjectController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            Message = "Server is running",
        });
    }
}