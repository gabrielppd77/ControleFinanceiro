using Application.Base;
using Application.FinancialTypes.Common;
using Contracts.Repositories.Base;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.ListFinancialType;

public class ListFinancialTypeService : IServiceHandler<Unit, List<FinancialTypeResponse>>
{
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;

    public ListFinancialTypeService(IBaseRepository<FinancialType> financialTypeRepository)
    {
        _financialTypeRepository = financialTypeRepository;
    }

    public async Task<List<FinancialTypeResponse>> Handle(Unit request)
    {
        var financialTypes = await _financialTypeRepository.GetAll();

        return financialTypes.Select(x => new FinancialTypeResponse(x.Id, x.Name)).ToList();
    }
}
