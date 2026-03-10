using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories;
using Contracts.Repositories.FinancialTypes;
using Domain.FinancialTypes;

namespace Application.FinancialTypes.CreateFinancialType;

public class CreateFinancialTypeService : IServiceHandler<CreateFinancialTypeRequest, Success>
{
    private readonly IFinancialTypeRepository _financialTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAuthenticated _userAuthenticated;

    public CreateFinancialTypeService(IFinancialTypeRepository financialTypeRepository, IUnitOfWork unitOfWork, IUserAuthenticated userAuthenticated)
    {
        _financialTypeRepository = financialTypeRepository;
        _unitOfWork = unitOfWork;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<Success> Handle(CreateFinancialTypeRequest request)
    {
        var userId = _userAuthenticated.GetUserId();

        var financialType = new FinancialType(request.Name, userId);

        await _financialTypeRepository.Add(financialType);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
