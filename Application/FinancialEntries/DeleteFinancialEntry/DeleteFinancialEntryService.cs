using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.FinancialEntries;

namespace Application.FinancialEntries.DeleteFinancialEntry;

public class DeleteFinancialEntryService : IServiceHandler<DeleteFinancialEntryRequest, Success>
{
    private readonly IBaseRepository<FinancialEntry> _financialEntryRepository;

    public DeleteFinancialEntryService(IBaseRepository<FinancialEntry> financialEntryRepository)
    {
        _financialEntryRepository = financialEntryRepository;
    }

    public async Task<Success> Handle(DeleteFinancialEntryRequest request)
    {
        var financialEntry = await _financialEntryRepository.GetById(request.Id);

        if (financialEntry is null) throw new NotFoundException("Não foi possível encontrar o Lançamento Financeiro");

        _financialEntryRepository.Remove(financialEntry);

        await _financialEntryRepository.SaveChanges();

        return Success.Value;
    }
}
