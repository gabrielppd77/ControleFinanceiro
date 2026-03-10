using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialEntries;
using Domain.Exceptions;

namespace Application.FinancialEntries.DeleteFinancialEntry;

public class DeleteFinancialEntryService : IServiceHandler<DeleteFinancialEntryRequest, Success>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFinancialEntryService(IFinancialEntryRepository financialEntryRepository, IUnitOfWork unitOfWork)
    {
        _financialEntryRepository = financialEntryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(DeleteFinancialEntryRequest request)
    {
        var financialEntry = await _financialEntryRepository.GetById(request.Id);

        if (financialEntry is null) throw new NotFoundException("Não foi possível encontrar o Lançamento Financeiro");

        _financialEntryRepository.Remove(financialEntry);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
