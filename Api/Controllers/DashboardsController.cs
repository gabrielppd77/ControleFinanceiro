using Api.Controllers.Base;
using Application.Base;
using Application.Dashboards.GetStatisticsMonth;
using Application.Dashboards.GetStatisticsMonth.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class DashboardsController : ApiController
{
    [HttpGet]
    public async Task<IActionResult> List(IServiceHandler<GetStatisticMonthRequest, GetStatisticMonthResponse> service, DateTime date)
    {
        var response = await service.Handle(new GetStatisticMonthRequest(date));
        return Ok(response);
    }
}
