using Application.Base;
using Contracts.Repositories.Base;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.CreateFinancialType;

public class CreateFinancialTypeService : IServiceHandler<CreateFinancialTypeRequest, Success>
{
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;

    public CreateFinancialTypeService(IBaseRepository<FinancialType> financialTypeRepository)
    {
        _financialTypeRepository = financialTypeRepository;
    }

    public async Task<Success> Handle(CreateFinancialTypeRequest request)
    {
        var financialType = new FinancialType(request.Name);

        await _financialTypeRepository.Add(financialType);

        await _financialTypeRepository.SaveChanges();

        return Success.Value;
    }
}
