using NhapHangV2.Entities.Report;
using NhapHangV2.Entities.Search.Report;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.Report
{
    public interface ITransportationOrderReportService : IReportService<TransportationOrderReport, TransportationOrderReportSearch>
    {
    }
}
