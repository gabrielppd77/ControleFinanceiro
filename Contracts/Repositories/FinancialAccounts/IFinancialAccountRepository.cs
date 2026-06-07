using Domain.FinancialAccounts;

namespace Contracts.Repositories.FinancialAccounts;

public interface IFinancialAccountRepository
{
    Task Add(FinancialAccount financialAccount);
    Task<List<FinancialAccount>> GetAll(Guid userId);
    Task<FinancialAccount?> GetById(Guid id);
    void Remove(FinancialAccount financialAccount);
}
