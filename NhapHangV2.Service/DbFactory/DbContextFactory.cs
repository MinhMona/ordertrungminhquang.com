using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.DbFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.DbFactory
{
    public abstract class DbContextFactory : IDbContextFactory
    {
        public abstract IAppDbContext Create();
    }
}
