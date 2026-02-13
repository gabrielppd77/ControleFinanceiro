using Application.Base;
using Contracts.Repositories;

namespace Application.FinancialEntrys.ListFinancialEntry;

public class ListFinancialEntryService : IServiceHandler<Unit, List<ListFinancialEntryResponse>>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;

    public ListFinancialEntryService(IFinancialEntryRepository financialEntryRepository)
    {
        _financialEntryRepository = financialEntryRepository;
    }

    public async Task<List<ListFinancialEntryResponse>> Handle(Unit request)
    {
        var financialEntrys = await _financialEntryRepository.GetAllToList();

        return financialEntrys
            .Select(x => new ListFinancialEntryResponse(
                x.Id,
                x.Date,
                x.Amount,
                x.TypeId,
                x.Type.Name,
                x.ClassificationId,
                x.Classification.Name,
                x.Description))
            .ToList();
    }
}
