using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCore.Infrastructure
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbSet<T> dbset;
        IDataBaseFactory dataBaseFactory;


        public RepositoryBase(IDataBaseFactory dbFactory)
        {
            this.dataBaseFactory = dbFactory;
            dbset = dbFactory.SteDataContext.Set<T>();
        }
      
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public T GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return dbset.Find(id);
        }

        public T GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> where = null, System.Linq.Expressions.Expression<Func<T, bool>> orderBy = null)
        {
            IQueryable<T> Query = dbset;
            if (where != null)
            {
                Query = Query.Where(where);
            }
            if (orderBy != null)
            {
                Query = Query.OrderBy(orderBy);
            }
            return Query;
        }

        public IEnumerable<T> GetManyWithInclude(System.Linq.Expressions.Expression<Func<T, bool>> where, System.Linq.Expressions.Expression<Func<T, bool>> orderBy, System.Linq.Expressions.Expression<Func<T, object>> include)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            dbset.Update(entity);
        }

        
    }
}
