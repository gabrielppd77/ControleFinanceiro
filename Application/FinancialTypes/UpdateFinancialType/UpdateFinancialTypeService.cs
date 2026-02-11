using Application.Base;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.UpdateFinancialType;

public class UpdateFinancialTypeService : IServiceHandler<UpdateFinancialTypeRequest, Success>
{
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;

    public UpdateFinancialTypeService(IBaseRepository<FinancialType> financialTypeRepository)
    {
        _financialTypeRepository = financialTypeRepository;
    }

    public async Task<Success> Handle(UpdateFinancialTypeRequest request)
    {
        var financialType = await _financialTypeRepository.GetById(request.Id);

        if (financialType is null) throw new NotFoundException("Não foi possível encontrar um Tipo");

        financialType.Update(request.Name);

        await _financialTypeRepository.SaveChanges();

        return Success.Value;
    }
}
