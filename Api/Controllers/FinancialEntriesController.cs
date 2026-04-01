using Api.Controllers.Base;
using Application.Base;
using Application.FinancialEntries.CreateFinancialEntry;
using Application.FinancialEntries.DeleteFinancialEntry;
using Application.FinancialEntries.GetFinancialEntries;
using Application.FinancialEntries.ListFinancialEntry;
using Application.FinancialEntries.UpdateFinancialEntry;
using Contracts.Repositories.FinancialEntries.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class FinancialEntriesController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IServiceHandler<CreateFinancialEntryRequest, Success> service, DateTime? replicateUntilDate, CreateFinancialEntryRequest request)
    {
        await service.Handle(new CreateFinancialEntryRequest(replicateUntilDate, request.Date, request.Amount, request.TypeId, request.ClassificationId, request.Description));
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

    [HttpPost("List")]
    public async Task<IActionResult> List(IServiceHandler<FinancialEntryFilterDto, List<ListFinancialEntryResponse>> service, FinancialEntryFilterDto request)
    {
        var response = await service.Handle(request);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(IServiceHandler<GetFinancialEntryRequest, GetFinancialEntryResponse> service, Guid id)
    {
        var response = await service.Handle(new GetFinancialEntryRequest(id));
        return Ok(response);
    }
}
