using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialAccounts;
using Domain.Exceptions;

namespace Application.FinancialAccounts.UpdateFinancialAccount;

public class UpdateFinancialAccountService : IServiceHandler<UpdateFinancialAccountRequest, Success>
{
    private readonly IFinancialAccountRepository _financialAccountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFinancialAccountService(IFinancialAccountRepository financialAccountRepository, IUnitOfWork unitOfWork)
    {
        _financialAccountRepository = financialAccountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(UpdateFinancialAccountRequest request)
    {
        var financialAccount = await _financialAccountRepository.GetById(request.Id);

        if (financialAccount is null) throw new NotFoundException("Não foi possível encontrar uma Conta");

        financialAccount.Update(request.Name, request.Color);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
