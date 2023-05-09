using API.Domain.Entities;

namespace API.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Product> ProductRepository { get; }
        IBaseRepository<Category> CategoryRepository { get; }
        void SaveChanges();
        void SaveChangesWithTransaction();
    }
}
