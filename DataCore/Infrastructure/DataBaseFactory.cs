using System;
using System.Collections.Generic;
using System.Text;

namespace DataCore.Infrastructure
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private SteDataBaseWebAllContext steDataContext;
        public SteDataBaseWebAllContext SteDataContext { get { return steDataContext; } }

        public DataBaseFactory()
        {
            steDataContext = new SteDataBaseWebAllContext();
        }

        protected override void DisposeCore()
        {
            if(SteDataContext != null)
            {
                SteDataContext.Dispose();
            }
        }
    }
}
