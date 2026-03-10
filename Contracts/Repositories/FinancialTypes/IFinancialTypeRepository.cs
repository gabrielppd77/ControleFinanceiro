using Domain.FinancialTypes;

namespace Contracts.Repositories.FinancialTypes;

public interface IFinancialTypeRepository
{
    Task Add(FinancialType financialType);
    Task<List<FinancialType>> GetAll(Guid userId);
    Task<FinancialType?> GetById(Guid id);
    void Remove(FinancialType financialType);
}
