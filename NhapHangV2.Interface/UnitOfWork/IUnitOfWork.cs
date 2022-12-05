using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICatalogueRepository<T> CatalogueRepository<T>() where T : AppDomainCatalogue;
        IDomainRepository<T> Repository<T>() where T : Entities.DomainEntities.AppDomain;
        void Save();
        Task SaveAsync();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
    }
}
