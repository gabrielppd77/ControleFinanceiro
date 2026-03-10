using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialEntries;
using Domain.FinancialEntries;

namespace Application.FinancialEntries.CreateFinancialEntry;

public class CreateFinancialEntryService : IServiceHandler<CreateFinancialEntryRequest, Success>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFinancialEntryService(IFinancialEntryRepository financialEntryRepository, IUnitOfWork unitOfWork)
    {
        _financialEntryRepository = financialEntryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(CreateFinancialEntryRequest request)
    {
        var financialEntry = new FinancialEntry(request.Date, request.Amount, request.TypeId, request.ClassificationId, request.Description);

        await _financialEntryRepository.Add(financialEntry);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
