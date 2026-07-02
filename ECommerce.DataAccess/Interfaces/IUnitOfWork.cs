using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository<T> Repository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
