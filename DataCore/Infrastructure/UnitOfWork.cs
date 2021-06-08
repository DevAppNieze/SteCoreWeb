using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataCore.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public SteDataBaseWebAllContext dataContext;

        IDataBaseFactory dbFactory;
        public UnitOfWork(IDataBaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.SteDataContext;

        }

        public void Commit()
        {
            try
            {

                dataContext.SaveChanges();
            }
            catch (ValidationException e)
            {
                foreach (var eve in e.Data)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.ToString());
                    
                }
                throw;
            }
        }

        public void CommitAsync()
        {
            dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }

        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }
    }
}
