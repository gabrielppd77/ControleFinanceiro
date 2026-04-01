using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories;
using Contracts.Repositories.FinancialEntries;
using Domain.FinancialEntries;

namespace Application.FinancialEntries.CreateFinancialEntry;

public class CreateFinancialEntryService : IServiceHandler<CreateFinancialEntryRequest, Success>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAuthenticated _userAuthenticated;

    public CreateFinancialEntryService(IFinancialEntryRepository financialEntryRepository, IUnitOfWork unitOfWork, IUserAuthenticated userAuthenticated)
    {
        _financialEntryRepository = financialEntryRepository;
        _unitOfWork = unitOfWork;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<Success> Handle(CreateFinancialEntryRequest request)
    {
        var userId = _userAuthenticated.GetUserId();

        if (request.ReplicateUntilDate is null)
        {
            await CreateOneFinancialEntry(request, userId);
        }
        else
        {
            await CreateManyFinancialEntry(request, userId);
        }

        return Success.Value;
    }

    private async Task CreateOneFinancialEntry(CreateFinancialEntryRequest request, Guid userId)
    {
        var financialEntry = new FinancialEntry(
            request.Date,
            request.Amount,
            request.TypeId,
            request.ClassificationId,
            request.Description,
            userId);

        await _financialEntryRepository.Add(financialEntry);

        await _unitOfWork.SaveChanges();
    }

    private async Task CreateManyFinancialEntry(CreateFinancialEntryRequest request, Guid userId)
    {
        var replicateUntilDate = request.ReplicateUntilDate!.Value;

        var currentDate = request.Date;

        var financialEntries = new List<FinancialEntry>();

        while (currentDate.Year < replicateUntilDate.Year ||
              (currentDate.Year == replicateUntilDate.Year && currentDate.Month <= replicateUntilDate.Month))
        {
            financialEntries.Add(new FinancialEntry(
                currentDate,
                request.Amount,
                request.TypeId,
                request.ClassificationId,
                request.Description,
                userId));

            currentDate = currentDate.AddMonths(1);
        }

        await _financialEntryRepository.AddRange(financialEntries);

        await _unitOfWork.SaveChanges();
    }
}
