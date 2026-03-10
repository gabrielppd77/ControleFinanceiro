using Domain.FinancialTypes;

namespace Contracts.Repositories.FinancialTypes;

public interface IFinancialTypeRepository
{
    Task Add(FinancialType financialType);
    Task<List<FinancialType>> GetAll();
    Task<FinancialType?> GetById(Guid id);
    void Remove(FinancialType financialType);
}
