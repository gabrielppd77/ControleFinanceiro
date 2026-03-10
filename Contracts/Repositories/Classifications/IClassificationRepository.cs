using Domain.Classifications;

namespace Contracts.Repositories.Classifications;

public interface IClassificationRepository
{
    Task Add(Classification classification);
    Task<List<Classification>> GetAll(Guid userId);
    Task<Classification?> GetById(Guid id);
    void Remove(Classification classification);
}
