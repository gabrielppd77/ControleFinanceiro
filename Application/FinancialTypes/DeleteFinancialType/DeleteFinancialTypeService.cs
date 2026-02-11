using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.DeleteFinancialType;

public class DeleteFinancialTypeService : IServiceHandler<DeleteFinancialTypeRequest, Success>
{
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;

    public DeleteFinancialTypeService(IBaseRepository<FinancialType> financialTypeRepository)
    {
        _financialTypeRepository = financialTypeRepository;
    }

    public async Task<Success> Handle(DeleteFinancialTypeRequest request)
    {
        var financialType = await _financialTypeRepository.GetById(request.Id);

        if (financialType is null) throw new NotFoundException("Não foi possível encontrar um Tipo");

        _financialTypeRepository.Remove(financialType);

        await _financialTypeRepository.SaveChanges();

        return Success.Value;
    }
}
