using Api.Controllers.Base;
using Application.Base;
using Application.FinancialAccounts.Common;
using Application.FinancialAccounts.CreateFinancialAccount;
using Application.FinancialAccounts.DeleteFinancialAccount;
using Application.FinancialAccounts.GetFinancialAccount;
using Application.FinancialAccounts.UpdateFinancialAccount;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class FinancialAccountsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IServiceHandler<CreateFinancialAccountRequest, Success> service, CreateFinancialAccountRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(IServiceHandler<UpdateFinancialAccountRequest, Success> service, UpdateFinancialAccountRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(IServiceHandler<DeleteFinancialAccountRequest, Success> service, Guid id)
    {
        await service.Handle(new DeleteFinancialAccountRequest(id));
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List(IServiceHandler<Unit, List<FinancialAccountResponse>> service)
    {
        var response = await service.Handle(Unit.Value);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(IServiceHandler<GetFinancialAccountRequest, FinancialAccountResponse> service, Guid id)
    {
        var response = await service.Handle(new GetFinancialAccountRequest(id));
        return Ok(response);
    }
}
