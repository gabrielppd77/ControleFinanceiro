using Application.Base;
using Contracts.Repositories.Base;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.ListFinancialType;

public class ListFinancialTypeService : IServiceHandler<Unit, List<ListFinancialTypeResponse>>
{
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;

    public ListFinancialTypeService(IBaseRepository<FinancialType> financialTypeRepository)
    {
        _financialTypeRepository = financialTypeRepository;
    }

    public async Task<List<ListFinancialTypeResponse>> Handle(Unit request)
    {
        var financialTypes = await _financialTypeRepository.GetAll();

        return financialTypes.Select(x => new ListFinancialTypeResponse(x.Id, x.Name)).ToList();
    }
}
