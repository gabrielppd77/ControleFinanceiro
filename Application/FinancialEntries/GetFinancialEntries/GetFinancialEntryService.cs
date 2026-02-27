using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.FinancialEntries;

namespace Application.FinancialEntries.GetFinancialEntries;

public class GetFinancialEntryService : IServiceHandler<GetFinancialEntryRequest, GetFinancialEntryResponse>
{
    private readonly IBaseRepository<FinancialEntry> _financialEntryRepository;

    public GetFinancialEntryService(IBaseRepository<FinancialEntry> financialEntryRepository)
    {
        _financialEntryRepository = financialEntryRepository;
    }

    public async Task<GetFinancialEntryResponse> Handle(GetFinancialEntryRequest request)
    {
        var financialEntry = await _financialEntryRepository.GetById(request.Id);

        if (financialEntry is null) throw new NotFoundException("Não foi possível encontrar o Lançamento Financeiro");

        return new GetFinancialEntryResponse(
            financialEntry.Id,
            financialEntry.Date,
            financialEntry.Amount,
            financialEntry.TypeId,
            financialEntry.ClassificationId,
            financialEntry.Description);
    }
}