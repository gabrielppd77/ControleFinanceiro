namespace Contracts.Repositories;

public interface IUnitOfWork
{
    Task SaveChanges();
}
