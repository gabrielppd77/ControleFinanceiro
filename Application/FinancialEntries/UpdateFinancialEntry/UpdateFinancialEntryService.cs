using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialEntries;
using Domain.Exceptions;

namespace Application.FinancialEntries.UpdateFinancialEntry;

public class UpdateFinancialEntryService : IServiceHandler<UpdateFinancialEntryRequest, Success>
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFinancialEntryService(IFinancialEntryRepository financialEntryRepository, IUnitOfWork unitOfWork)
    {
        _financialEntryRepository = financialEntryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(UpdateFinancialEntryRequest request)
    {
        var financialEntry = await _financialEntryRepository.GetById(request.Id);

        if (financialEntry is null) throw new NotFoundException("Não foi possível encontrar o Lançamento Financeiro");

        financialEntry.Update(request.Date, request.Amount, request.TypeId, request.ClassificationId, request.Description);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
