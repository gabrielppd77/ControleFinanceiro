namespace Contracts.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task Add(TEntity entity);
    Task<TEntity?> GetById(Guid entityId);
    Task<List<TEntity>> GetAll();
    void Remove(TEntity entity);
    Task SaveChanges();
}
