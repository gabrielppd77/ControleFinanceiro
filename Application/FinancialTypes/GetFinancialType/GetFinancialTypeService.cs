using Application.Base;
using Application.FinancialTypes.Common;
using Contracts.Repositories.Base;
using Domain.Exceptions;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.GetFinancialType;

public class GetFinancialTypeService : IServiceHandler<GetFinancialTypeRequest, FinancialTypeResponse>
{
    private readonly IBaseRepository<FinancialType> _financialTypeRepository;

    public GetFinancialTypeService(IBaseRepository<FinancialType> financialTypeRepository)
    {
        _financialTypeRepository = financialTypeRepository;
    }

    public async Task<FinancialTypeResponse> Handle(GetFinancialTypeRequest request)
    {
        var financialType = await _financialTypeRepository.GetById(request.Id);

        if (financialType is null) throw new NotFoundException("Não foi possível encontrar um Tipo");

        return new FinancialTypeResponse(financialType.Id, financialType.Name);
    }
}