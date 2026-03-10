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

        var financialEntry = new FinancialEntry(request.Date, request.Amount, request.TypeId, request.ClassificationId, request.Description, userId);

        await _financialEntryRepository.Add(financialEntry);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
