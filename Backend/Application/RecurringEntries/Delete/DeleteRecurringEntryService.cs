using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.RecurringEntries;
using Domain.Exceptions;

namespace Application.RecurringEntries.DeleteRecurringEntry;

public class DeleteRecurringEntryService : IServiceHandler<DeleteRecurringEntryRequest, Success>
{
    private readonly IRecurringEntryRepository _recurringEntryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRecurringEntryService(IRecurringEntryRepository recurringEntryRepository, IUnitOfWork unitOfWork)
    {
        _recurringEntryRepository = recurringEntryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(DeleteRecurringEntryRequest request)
    {
        var recurringEntry = await _recurringEntryRepository.GetById(request.Id);

        if (recurringEntry is null) throw new NotFoundException("Não foi possível encontrar o Lançamento Recorrente");

        _recurringEntryRepository.Remove(recurringEntry);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
