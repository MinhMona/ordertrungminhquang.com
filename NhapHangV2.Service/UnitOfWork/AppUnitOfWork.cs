using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.DbFactory;
using NhapHangV2.Interface.Repository;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Service
{
    public class AppUnitOfWork : UnitOfWork, IAppUnitOfWork
    {
        readonly IAppDbContext appDbContext;
        public AppUnitOfWork(IAppDbContext context) : base(context)
        {
            appDbContext = context;
        }
        public AppUnitOfWork(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
            appDbContext = dbContextFactory.Create();
        }

        public override ICatalogueRepository<T> CatalogueRepository<T>()
        {
            return new CatalogueRepository<T>(appDbContext);
        }

        public override IDomainRepository<T> Repository<T>()
        {
            return new AppRepository<T>(appDbContext);
        }
    }
}
