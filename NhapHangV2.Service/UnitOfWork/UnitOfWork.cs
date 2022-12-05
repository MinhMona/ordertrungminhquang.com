using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.Repository;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.DbFactory;

namespace NhapHangV2.Service
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected IAppDbContext context;
        public UnitOfWork(IAppDbContext context)
        {
            this.context = context;
            if (this.context != null)
            {
                this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                this.context.ChangeTracker.AutoDetectChangesEnabled = false;
            }
        }

        public UnitOfWork(IDbContextFactory dbContextFactory)
        {
            context = dbContextFactory.Create();
            if (context != null)
            {
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
        }

        public abstract ICatalogueRepository<T> CatalogueRepository<T>() where T : AppDomainCatalogue;

        public abstract IDomainRepository<T> Repository<T>() where T : Entities.DomainEntities.AppDomain;

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return context.SaveChanges(acceptAllChangesOnSuccess);
        }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return context.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
