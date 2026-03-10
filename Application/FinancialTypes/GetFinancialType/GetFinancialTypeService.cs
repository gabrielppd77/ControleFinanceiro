using Application.Base;
using Application.FinancialTypes.Common;
using Contracts.Repositories.FinancialTypes;
using Domain.Exceptions;

namespace Application.FinancialTypes.GetFinancialType;

public class GetFinancialTypeService : IServiceHandler<GetFinancialTypeRequest, FinancialTypeResponse>
{
    private readonly IFinancialTypeRepository _financialTypeRepository;

    public GetFinancialTypeService(IFinancialTypeRepository financialTypeRepository)
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