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
    [Route("api/report-main-order-revenue")]
    [ApiController]
    [Description("Thống kê doanh thu cho sale và đặt hàng")]
    [Authorize]
    public class MainOrderRevenueReportController : BaseReportController<MainOrderRevenueReport, MainOrderRevenueReportModel, MainOrderRevenueReportSearch>
    {
        public MainOrderRevenueReportController(IServiceProvider serviceProvider, ILogger<BaseReportController<MainOrderRevenueReport, MainOrderRevenueReportModel, MainOrderRevenueReportSearch>> logger, IWebHostEnvironment env, IConfiguration configuration) : base(serviceProvider, logger, env, configuration)
        {
            this.domainService = serviceProvider.GetRequiredService<IMainOrderRevenueReportService>();
        }

        protected override string GetTemplateFilePath(string fileTemplateName)
        {
            return base.GetTemplateFilePath("MainOrderRevenueReportTemplate.xlsx");
        }

        protected override string GetReportName()
        {
            return "MainOrderRevenue_Report";
        }
    }
}
