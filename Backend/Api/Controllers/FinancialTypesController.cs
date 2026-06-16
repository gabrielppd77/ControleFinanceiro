using Api.Controllers.Base;
using Application.Base;
using Application.FinancialTypes.Common;
using Application.FinancialTypes.CreateFinancialType;
using Application.FinancialTypes.DeleteFinancialType;
using Application.FinancialTypes.GetFinancialType;
using Application.FinancialTypes.UpdateFinancialType;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class FinancialTypesController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IServiceHandler<CreateFinancialTypeRequest, Success> service, CreateFinancialTypeRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(IServiceHandler<UpdateFinancialTypeRequest, Success> service, UpdateFinancialTypeRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(IServiceHandler<DeleteFinancialTypeRequest, Success> service, Guid id)
    {
        await service.Handle(new DeleteFinancialTypeRequest(id));
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List(IServiceHandler<Unit, List<FinancialTypeResponse>> service)
    {
        var response = await service.Handle(Unit.Value);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(IServiceHandler<GetFinancialTypeRequest, FinancialTypeResponse> service, Guid id)
    {
        var response = await service.Handle(new GetFinancialTypeRequest(id));
        return Ok(response);
    }
}
