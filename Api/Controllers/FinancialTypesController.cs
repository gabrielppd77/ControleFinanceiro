using Api.Controllers.Base;
using Application.Base;
using Application.FinancialTypes.CreateFinancialType;
using Application.FinancialTypes.DeleteFinancialType;
using Application.FinancialTypes.ListFinancialType;
using Application.FinancialTypes.UpdateFinancialType;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class FinancialTypesController : ApiController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(IServiceHandler<CreateFinancialTypeRequest, Success> service, CreateFinancialTypeRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(IServiceHandler<UpdateFinancialTypeRequest, Success> service, UpdateFinancialTypeRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete(IServiceHandler<DeleteFinancialTypeRequest, Success> service, Guid id)
    {
        await service.Handle(new DeleteFinancialTypeRequest(id));
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> List(IServiceHandler<Unit, List<ListFinancialTypeResponse>> service)
    {
        var response = await service.Handle(Unit.Value);
        return Ok(response);
    }
}
