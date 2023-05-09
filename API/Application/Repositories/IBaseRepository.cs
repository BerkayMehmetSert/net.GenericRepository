using System.Linq.Expressions;
using API.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        List<T> GetAll(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        T Get(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
