using Api.Controllers.Base;
using Application.Base;
using Application.Importations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class ImportationsController : ApiController
{
    [HttpPost("Csv")]
    public async Task<IActionResult> ImportCsv(
        IServiceHandler<ImportationCSVRequest, ImportationCSVResponse> service,
        IFormFile file,
        DateOnly dateFinancialEntry,
        Guid? accountId)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Arquivo inválido.");

        await using var stream = file.OpenReadStream();
        var response = await service.Handle(new ImportationCSVRequest(dateFinancialEntry, stream, accountId));
        return Ok(response);
    }
}
