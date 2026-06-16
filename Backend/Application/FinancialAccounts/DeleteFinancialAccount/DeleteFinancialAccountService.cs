using Application.Base;
using Contracts.Repositories;
using Contracts.Repositories.FinancialAccounts;
using Domain.Exceptions;

namespace Application.FinancialAccounts.DeleteFinancialAccount;

public class DeleteFinancialAccountService : IServiceHandler<DeleteFinancialAccountRequest, Success>
{
    private readonly IFinancialAccountRepository _financialAccountRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFinancialAccountService(IFinancialAccountRepository financialAccountRepository, IUnitOfWork unitOfWork)
    {
        _financialAccountRepository = financialAccountRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Success> Handle(DeleteFinancialAccountRequest request)
    {
        var financialAccount = await _financialAccountRepository.GetById(request.Id);

        if (financialAccount is null) throw new NotFoundException("Não foi possível encontrar uma Conta");

        _financialAccountRepository.Remove(financialAccount);

        await _unitOfWork.SaveChanges();

        return Success.Value;
    }
}
