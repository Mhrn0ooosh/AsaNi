using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsaNi.Business.Contracts
{
   public interface IBaseManager<T>
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
    }
}
