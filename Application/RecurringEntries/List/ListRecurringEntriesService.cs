using Application.Base;
using Application.RecurringEntries.Common;
using Contracts.Authentications;
using Contracts.Repositories.RecurringEntries;

namespace Application.RecurringEntries.ListRecurringEntries;

public class ListRecurringEntriesService : IServiceHandler<Unit, List<RecurringEntryResponse>>
{
    private readonly IRecurringEntryRepository _recurringEntryRepository;
    private readonly IUserAuthenticated _userAuthenticated;

    public ListRecurringEntriesService(IRecurringEntryRepository recurringEntryRepository, IUserAuthenticated userAuthenticated)
    {
        _recurringEntryRepository = recurringEntryRepository;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<List<RecurringEntryResponse>> Handle(Unit request)
    {
        var userId = _userAuthenticated.GetUserId();

        var recurringEntries = await _recurringEntryRepository.GetAll(userId);

        return recurringEntries
            .Select(x => new RecurringEntryResponse(x.Id, x.Description, x.Amount, x.Classification, x.DayOfMonth, x.StartDate, x.EndDate, x.IsActive, x.TypeId, x.AccountId))
            .ToList();
    }
}
