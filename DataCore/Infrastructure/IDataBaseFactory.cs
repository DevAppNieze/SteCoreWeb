using System;

namespace DataCore.Infrastructure
{
    public interface IDataBaseFactory : IDisposable
    {
        public SteDataBaseWebAllContext SteDataContext { get; }
    }
}