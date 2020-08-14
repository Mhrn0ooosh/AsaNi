using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AsaNi.DataAccess.Repositories.Contracts
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
