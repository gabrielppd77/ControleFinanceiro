using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.FinancialEntries;

namespace Application.FinancialEntrys.UpdateFinancialEntry;

public class UpdateFinancialEntryService : IServiceHandler<UpdateFinancialEntryRequest, Success>
{
    private readonly IBaseRepository<FinancialEntry> _financialEntryRepository;

    public UpdateFinancialEntryService(IBaseRepository<FinancialEntry> financialEntryRepository)
    {
        _financialEntryRepository = financialEntryRepository;
    }

    public async Task<Success> Handle(UpdateFinancialEntryRequest request)
    {
        var financialEntry = await _financialEntryRepository.GetById(request.Id);

        if (financialEntry is null) throw new NotFoundException("Não foi possível encontrar o Lançamento Financeiro");

        financialEntry.Update(request.Date, request.Amount, request.TypeId, request.ClassificationId, request.Description);

        await _financialEntryRepository.SaveChanges();

        return Success.Value;
    }
}
