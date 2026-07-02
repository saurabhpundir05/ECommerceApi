using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ECommerce.DataAccess.Interfaces
{
    public interface IEntityRepository<T> : IDisposable where T : class
    {
        IList<T> Select(Expression<Func<T, bool>> expression);
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(int id);
        void Insert(T entity);
        void Delete(int id);
    }
}
