using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.DbFactory;
using NhapHangV2.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhapHangV2.Service.Repository
{
    public class CatalogueRepository<T> : DomainRepository<T>, ICatalogueRepository<T> where T: AppDomainCatalogue
    {
        public CatalogueRepository(IAppDbContext context) : base(context)
        {

        }

        public CatalogueRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {

        }

        public T GetByCode(string code)
        {
            return Context.Set<T>().FirstOrDefault(e => e.Code == code);
        }

        public void Delete(int id)
        {
            T entity = Context.Set<T>().FirstOrDefault(e => e.Id == id);
            entity.Deleted = true;
            Context.Set<T>().Update(entity);
        }
        public override void Delete(T entity)
        {
            entity.Deleted = true;
            Context.Set<T>().Update(entity);
        }
    }
}
