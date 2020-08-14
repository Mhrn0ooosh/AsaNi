using AsaNi.Business.Contracts;
using AsaNi.DataAccess.Repositories;
using AsaNi.DataAccess.Repositories.Contracts;
using AsaNi.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AsaNi.Business
{
    public class HouseManager : IHouseManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public HouseManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(House entity)
        {
            _unitOfWork.House.Create(entity);
            _unitOfWork.Save();
        }

        public void Delete(House entity)
        {
            var foundHouse = _unitOfWork.House.GetById(entity.Id);
            foundHouse.IsDeleted = true;
            _unitOfWork.House.Update(foundHouse);
            _unitOfWork.Save();
        }

        public IQueryable<House> GetAll()
        {
            return _unitOfWork.House.GetAll().Where(x => x.IsDeleted == false);
        }

        public House GetById(int id)
        {
            return _unitOfWork.House.GetById(id);
        }

        public void Update(House entity)
        {
            _unitOfWork.House.Update(entity);
            _unitOfWork.Save();
        }

    }
}
