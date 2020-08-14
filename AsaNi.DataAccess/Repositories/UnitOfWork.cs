using AsaNi.DataAccess.Context;
using AsaNi.DataAccess.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaNi.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AsaNiDBContext AsaNiDBContext { get; }
        public UnitOfWork(AsaNiDBContext asaNiDBContext)
        {
            AsaNiDBContext = asaNiDBContext;
            House = new HouseRepository(AsaNiDBContext);
            Owner = new OwnerRepository(AsaNiDBContext);
        }

        public HouseRepository House { get; }
        public OwnerRepository Owner { get; }

        public void Save()
        {
            AsaNiDBContext.SaveChanges();
        }

        public void Dispose()
        {
            AsaNiDBContext.Dispose();
        }
    }
}

