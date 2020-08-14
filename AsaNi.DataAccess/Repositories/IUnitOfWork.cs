using AsaNi.DataAccess.Context;
using AsaNi.DataAccess.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaNi.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        HouseRepository House { get; }
        OwnerRepository Owner { get; }

        AsaNiDBContext AsaNiDBContext { get; }
        void Save();
    }
}
