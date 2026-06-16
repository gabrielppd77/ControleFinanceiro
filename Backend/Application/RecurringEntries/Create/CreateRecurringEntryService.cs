using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories;
using Contracts.Repositories.RecurringEntries;
using Domain.RecurringEntries;

namespace Application.RecurringEntries.CreateRecurringEntry;

public class CreateRecurringEntryService : IServiceHandler<CreateRecurringEntryRequest, Success>
{
    private readonly IRecurringEntryRepository _recurringEntryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAuthenticated _userAuthenticated;

    public CreateRecurringEntryService(IRecurringEntryRepository recurringEntryRepository, IUnitOfWork unitOfWork, IUserAuthenticated userAuthenticated)
    {
        _recurringEntryRepository = recurringEntryRepository;
        _unitOfWork = unitOfWork;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<Success> Handle(CreateRecurringEntryRequest request)
    {
        var userId = _userAuthenticated.GetUserId();

        var recurringEntry = new RecurringEntry(request.Description, request.Amount, request.Classification, request.DayOfMonth, request.StartDate, request.EndDate, userId, request.TypeId, request.AccountId);

        await _recurringEntryRepository.Add(recurringEntry);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
