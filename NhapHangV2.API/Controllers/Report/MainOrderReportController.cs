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
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services.Report;
using NhapHangV2.Models.Report;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers.Report
{
    [Route("api/report-main-order")]
    [ApiController]
    [Description("Thống kê đơn hàng - Thống kê lợi nhuận mua hàng hộ")]
    [Authorize]
    public class MainOrderReportController : BaseReportController<MainOrderReport, MainOrderReportModel, MainOrderReportSearch>
    {
        private IMainOrderReportService mainOrderReportService;
        public MainOrderReportController(IServiceProvider serviceProvider, ILogger<BaseReportController<MainOrderReport, MainOrderReportModel, MainOrderReportSearch>> logger, IWebHostEnvironment env, IConfiguration configuration) : base(serviceProvider, logger, env, configuration)
        {
            this.domainService = serviceProvider.GetRequiredService<IMainOrderReportService>();
            mainOrderReportService = serviceProvider.GetRequiredService<IMainOrderReportService>();
        }

        protected override string GetTemplateFilePath(string fileTemplateName)
        {
            return base.GetTemplateFilePath("MainOrderReportTemplate.xlsx");
        }

        protected override string GetReportName()
        {
            return "MainOrder_Report";
        }



        
        [Description("Thống kê tống quát đơn hàng - doanh thu")]
        [HttpGet("get-total-overview")]
        [AppAuthorize(new int[] { CoreContants.ViewAll })]
        public virtual async Task<AppDomainResult> GetTotalRevenue([FromQuery] MainOrderReportSearch baseSearch)
        {
            AppDomainResult appDomainResult = new AppDomainResult();

            if (ModelState.IsValid)
            {
                List<MainOrderReportOverView> pagedData = await mainOrderReportService.GetRevenueOverview(baseSearch);
               // PagedList<MainOrderReportModel> pagedDataModel = mapper.Map<PagedList<MainOrderReportModel>>(pagedData);
                appDomainResult = new AppDomainResult
                {
                    Data = pagedData,
                    Success = true,
                    ResultCode = (int)HttpStatusCode.OK
                };
            }
            else
                throw new AppException(ModelState.GetErrorMessage());

            return appDomainResult;
        }

    }
}
