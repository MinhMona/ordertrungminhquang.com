using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.DomainServices
{
    public interface IReportService<E, T> where E : Entities.DomainEntities.AppDomainReport where T : BaseSearch
    {
        Task<PagedList<E>> GetPagedListData(T baseSearch);
    }
}
