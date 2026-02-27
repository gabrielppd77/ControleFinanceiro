using Application.Base;
using Contracts.Repositories.Base;
using Domain.FinancialEntries;

namespace Application.FinancialEntries.CreateFinancialEntry;

public class CreateFinancialEntryService : IServiceHandler<CreateFinancialEntryRequest, Success>
{
    private readonly IBaseRepository<FinancialEntry> _financialEntryRepository;

    public CreateFinancialEntryService(IBaseRepository<FinancialEntry> financialEntryRepository)
    {
        _financialEntryRepository = financialEntryRepository;
    }

    public async Task<Success> Handle(CreateFinancialEntryRequest request)
    {
        var financialEntry = new FinancialEntry(request.Date, request.Amount, request.TypeId, request.ClassificationId, request.Description);

        await _financialEntryRepository.Add(financialEntry);

        await _financialEntryRepository.SaveChanges();

        return Success.Value;
    }
}
