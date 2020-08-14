using AsaNi.DataAccess.Context;
using AsaNi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AsaNi.DataAccess.Repositories.Repository
{
    public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        protected AsaNiDBContext AsaNiDBContext { get; set; }

        public RepositoryBase(AsaNiDBContext asaNiDBContext)
        {
            AsaNiDBContext = asaNiDBContext;
        }

        public IQueryable<T> GetAll()
        {
            return GetQuery(true).AsNoTracking();
        }

        public void Create(T entity)
        {
            AsaNiDBContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            AsaNiDBContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            AsaNiDBContext.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetQuery(bool eager = true)
        {
            var query = AsaNiDBContext.Set<T>().AsQueryable();
            if (eager)
            {
                foreach (var property in AsaNiDBContext.Model.FindEntityType(typeof(T)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }

        public T GetById(int id)
        {
            var includedQuery = GetQuery(true);

            foreach (var item in includedQuery.ToList())
            {
                var objId = item.GetType().GetProperty("Id").GetValue(item);
                if ((int)objId == id)
                {
                    var foundHouse = AsaNiDBContext.Set<T>().Find(id);
                    return foundHouse;
                }
            }
            return null;
        }
    }
}
