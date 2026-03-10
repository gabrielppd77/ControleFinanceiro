using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialTypes;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.CreateFinancialType;

public class CreateFinancialTypeService : IServiceHandler<CreateFinancialTypeRequest, Success>
{
    private readonly IFinancialTypeRepository _financialTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFinancialTypeService(IFinancialTypeRepository financialTypeRepository, IUnitOfWork unitOfWork)
    {
        _financialTypeRepository = financialTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(CreateFinancialTypeRequest request)
    {
        var financialType = new FinancialType(request.Name);

        await _financialTypeRepository.Add(financialType);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
