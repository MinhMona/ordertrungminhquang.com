using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services
{
    public interface IExportRequestTurnService : IDomainService<ExportRequestTurn, ExportRequestTurnSearch>
    {
        Task<bool> Export(int id, List<int> smallPackageIds, bool isRequest);

        Task<bool> UpdateStatus(int id, int status, bool isPaymentWallet);
    }
}
