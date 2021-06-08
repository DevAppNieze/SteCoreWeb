using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> getRepository<T>() where T : class;
        void CommitAsync();
        void Commit();
    }
}
