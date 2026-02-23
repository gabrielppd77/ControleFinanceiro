using Api.Controllers.Base;
using Application.Base;
using Application.FinancialEntrys.CreateFinancialEntry;
using Application.FinancialEntrys.DeleteFinancialEntry;
using Application.FinancialEntrys.ListFinancialEntry;
using Application.FinancialEntrys.UpdateFinancialEntry;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class FinancialEntriesController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IServiceHandler<CreateFinancialEntryRequest, Success> service, CreateFinancialEntryRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(IServiceHandler<UpdateFinancialEntryRequest, Success> service, UpdateFinancialEntryRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(IServiceHandler<DeleteFinancialEntryRequest, Success> service, Guid id)
    {
        await service.Handle(new DeleteFinancialEntryRequest(id));
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List(IServiceHandler<Unit, List<ListFinancialEntryResponse>> service)
    {
        var response = await service.Handle(Unit.Value);
        return Ok(response);
    }
}
