using Application.Base;
using Application.FinancialAccounts.Common;
using Contracts.Repositories.FinancialAccounts;
using Domain.Exceptions;

namespace Application.FinancialAccounts.GetFinancialAccount;

public class GetFinancialAccountService : IServiceHandler<GetFinancialAccountRequest, FinancialAccountResponse>
{
    private readonly IFinancialAccountRepository _financialAccountRepository;

    public GetFinancialAccountService(IFinancialAccountRepository financialAccountRepository)
    {
        _financialAccountRepository = financialAccountRepository;
    }

    public async Task<FinancialAccountResponse> Handle(GetFinancialAccountRequest request)
    {
        var financialAccount = await _financialAccountRepository.GetById(request.Id);

        if (financialAccount is null) throw new NotFoundException("Não foi possível encontrar uma Conta");

        return new FinancialAccountResponse(financialAccount.Id, financialAccount.Name, financialAccount.Color);
    }
}
