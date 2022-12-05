using AutoMapper;
using NhapHangV2.Entities.Report;
using NhapHangV2.Entities.Search.Report;
using NhapHangV2.Interface.DbContext;
using NhapHangV2.Interface.Services.Report;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services.Report
{
    public class TransportationOrderReportService : ReportService<TransportationOrderReport, TransportationOrderReportSearch>, ITransportationOrderReportService
    {
        public TransportationOrderReportService(IAppUnitOfWork unitOfWork, IMapper mapper, IAppDbContext context) : base(unitOfWork, mapper, context)
        {
        }

        protected override string GetStoreProcName()
        {
            return "Report_TransportationOrder";
        }
    }
}
