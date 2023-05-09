using API.Application.Repositories;
using API.Domain.Entities;
using API.Persistence.Context;

namespace API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;
        private bool _disposed = false;

        public IBaseRepository<Product> ProductRepository { get; private set; }
        public IBaseRepository<Category> CategoryRepository { get; private set; }

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
            ProductRepository = new BaseRepository<Product>(context);
            CategoryRepository = new BaseRepository<Category>(context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void SaveChangesWithTransaction()
        {
            using var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {            
                dbContextTransaction.Rollback();
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
        }
    }
}
