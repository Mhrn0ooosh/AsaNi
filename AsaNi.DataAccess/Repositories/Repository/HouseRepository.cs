using AsaNi.DataAccess.Context;
using AsaNi.DataAccess.Repositories.Contracts;
using AsaNi.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AsaNi.DataAccess.Repositories.Repository
{
    public class HouseRepository : RepositoryBase<House>, IHouseRepository
    {
        public HouseRepository(AsaNiDBContext asaNiDBContext)
            : base(asaNiDBContext)
        {
        }
    }
}
