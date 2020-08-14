using AsaNi.DataAccess.Context;
using AsaNi.DataAccess.Repositories.Contracts;
using AsaNi.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaNi.DataAccess.Repositories.Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(AsaNiDBContext asaNiDBContext)
            : base(asaNiDBContext)
        {
        }
    }
}
