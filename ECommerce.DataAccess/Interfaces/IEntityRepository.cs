using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.DataAccess.Interfaces
{
    public interface IEntityRepository<T> where T : class
    {
        Task<IList<T>> SelectAsync(Expression<Func<T, bool>> expression);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T?> FindAsync(params object[] keyValues);
        void Insert(T entity);
    }
}