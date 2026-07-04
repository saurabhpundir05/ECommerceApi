#region imports
using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
#endregion

#region Entity Repository
namespace ECommerce.DataAccess.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly EcommerceDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepository(EcommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IList<T>> SelectAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
        public async Task<T?> FindAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
    }
}
#endregion