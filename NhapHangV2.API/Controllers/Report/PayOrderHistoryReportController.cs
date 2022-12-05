using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities.Report;
using NhapHangV2.Entities.Search.Report;
using NhapHangV2.Interface.Services.Report;
using NhapHangV2.Models.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers.Report
{
    [Route("api/report-pay-order-history")]
    [ApiController]
    [Description("Thống kê thanh toán")]
    [Authorize]
    public class PayOrderHistoryReportController : BaseReportController<PayOrderHistoryReport, PayOrderHistoryReportModel, PayOrderHistoryReportSearch>
    {
        public PayOrderHistoryReportController(IServiceProvider serviceProvider, ILogger<BaseReportController<PayOrderHistoryReport, PayOrderHistoryReportModel, PayOrderHistoryReportSearch>> logger, IWebHostEnvironment env, IConfiguration configuration) : base(serviceProvider, logger, env, configuration)
        {
            this.domainService = serviceProvider.GetRequiredService<IPayOrderHistoryReportService>();
        }

        protected override string GetTemplateFilePath(string fileTemplateName)
        {
            return base.GetTemplateFilePath("PayOrderHistoryReportTemplate.xlsx");
        }

        protected override string GetReportName()
        {
            return "PayOrderHistory_Report";
        }
    }
}
