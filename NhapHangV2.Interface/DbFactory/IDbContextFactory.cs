using NhapHangV2.Interface.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.DbFactory
{
    public interface IDbContextFactory
    {
        IAppDbContext Create();
    }
}
