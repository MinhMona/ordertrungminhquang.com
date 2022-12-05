using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.DbFactory;
using NhapHangV2.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Service.Repository
{
    public class AppRepository<T> : DomainRepository<T>, IAppRepository<T> where T : Entities.DomainEntities.AppDomain
    {
        public AppRepository(IAppDbContext context) : base(context)
        {

        }

        public AppRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }
    }
}
