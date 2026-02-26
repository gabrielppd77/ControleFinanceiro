using Api.Controllers.Base;
using Application.Base;
using Application.Classifications.Common;
using Application.Classifications.CreateClassification;
using Application.Classifications.DeleteClassification;
using Application.Classifications.GetClassification;
using Application.Classifications.UpdateClassification;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class ClassificationsController : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(IServiceHandler<CreateClassificationRequest, Success> service, CreateClassificationRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(IServiceHandler<UpdateClassificationRequest, Success> service, UpdateClassificationRequest request)
    {
        await service.Handle(request);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(IServiceHandler<DeleteClassificationRequest, Success> service, Guid id)
    {
        await service.Handle(new DeleteClassificationRequest(id));
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List(IServiceHandler<Unit, List<ClassificationResponse>> service)
    {
        var response = await service.Handle(Unit.Value);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(IServiceHandler<GetClassificationRequest, ClassificationResponse> service, Guid id)
    {
        var response = await service.Handle(new GetClassificationRequest(id));
        return Ok(response);
    }
}
