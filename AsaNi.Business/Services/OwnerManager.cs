using AsaNi.Business.Contracts;
using AsaNi.DataAccess.Repositories;
using AsaNi.DataAccess.Repositories.Contracts;
using AsaNi.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AsaNi.Business
{
    public class OwnerManager : IOwnerManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public OwnerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Owner entity)
        {
            _unitOfWork.Owner.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(Owner entity)
        {
            _unitOfWork.Owner.Delete(entity);
            _unitOfWork.Save();
        }

        public IQueryable<Owner> GetAll()
        {
            return _unitOfWork.Owner.GetAll();
        }

        public Owner GetById(int id)
        {
            return _unitOfWork.Owner.GetById(id);
        }

        public void Update(Owner entity)
        {
            _unitOfWork.Owner.Update(entity);
            _unitOfWork.Save();
        }
    }
}
