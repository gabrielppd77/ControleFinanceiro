using Application.Base;
using Contracts.Authentications;
using Contracts.Repositories;
using Contracts.Repositories.FinancialAccounts;
using Domain.FinancialAccounts;

namespace Application.FinancialAccounts.CreateFinancialAccount;

public class CreateFinancialAccountService : IServiceHandler<CreateFinancialAccountRequest, Success>
{
    private readonly IFinancialAccountRepository _financialAccountRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserAuthenticated _userAuthenticated;

    public CreateFinancialAccountService(IFinancialAccountRepository financialAccountRepository, IUnitOfWork unitOfWork, IUserAuthenticated userAuthenticated)
    {
        _financialAccountRepository = financialAccountRepository;
        _unitOfWork = unitOfWork;
        _userAuthenticated = userAuthenticated;
    }

    public async Task<Success> Handle(CreateFinancialAccountRequest request)
    {
        var userId = _userAuthenticated.GetUserId();

        var financialAccount = new FinancialAccount(request.Name, request.Color, userId);

        await _financialAccountRepository.Add(financialAccount);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
