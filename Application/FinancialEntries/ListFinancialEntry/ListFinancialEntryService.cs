using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories.FinancialEntries;

namespace Application.FinancialEntries.ListFinancialEntry;

public class ListFinancialEntryService : IServiceHandler<Unit, List<ListFinancialEntryResponse>>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IUserAuthenticated _userAuthenticated;

    public ListFinancialEntryService(IFinancialEntryRepository financialEntryRepository, IUserAuthenticated userAuthenticated)
    {
        _financialEntryRepository = financialEntryRepository;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<List<ListFinancialEntryResponse>> Handle(Unit request)
    {
        var userId = _userAuthenticated.GetUserId();

        var financialEntrys = await _financialEntryRepository.GetAll(userId);

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
