using Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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