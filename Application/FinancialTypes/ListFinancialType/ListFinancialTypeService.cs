using Application.Base;
using Application.FinancialTypes.Common;
using Contracts.Authentications;
using Contracts.Repositories.FinancialTypes;

namespace Application.FinancialTypes.ListFinancialType;

public class ListFinancialTypeService : IServiceHandler<Unit, List<FinancialTypeResponse>>
{
    private readonly IFinancialTypeRepository _financialTypeRepository;
    private readonly IUserAuthenticated _userAuthenticated;

    public ListFinancialTypeService(IFinancialTypeRepository financialTypeRepository, IUserAuthenticated userAuthenticated)
    {
        _financialTypeRepository = financialTypeRepository;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<List<FinancialTypeResponse>> Handle(Unit request)
    {
        var userId = _userAuthenticated.GetUserId();

        var financialTypes = await _financialTypeRepository.GetAll(userId);

        return financialTypes.Select(x => new FinancialTypeResponse(x.Id, x.Name)).ToList();
    }
}
