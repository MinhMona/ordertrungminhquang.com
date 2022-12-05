using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Models;
using NhapHangV2.Request;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers
{
    [Route("api/export-request-turn")]
    [ApiController]
    [Description("Thống kê cước ký gửi")]
    [Authorize]
    public class ExportRequestTurnController : BaseController<ExportRequestTurn, ExportRequestTurnModel, ExportRequestTurnRequest, ExportRequestTurnSearch>
    {
        protected IConfiguration configuration;
        protected readonly IExportRequestTurnService exportRequestTurnService;
        public ExportRequestTurnController(IServiceProvider serviceProvider, ILogger<BaseController<ExportRequestTurn, ExportRequestTurnModel, ExportRequestTurnRequest, ExportRequestTurnSearch>> logger, IWebHostEnvironment env, IConfiguration configuration) : base(serviceProvider, logger, env)
        {
            this.configuration = configuration;
            this.domainService = this.serviceProvider.GetRequiredService<IExportRequestTurnService>();
            exportRequestTurnService = serviceProvider.GetRequiredService<IExportRequestTurnService>();
        }

        /// <summary>
        /// Cập nhật các trạng thái như Thanh toán bằng ví, thanh toán trực tiếp, hủy
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPut("update-status")]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public async Task<AppDomainResult> UpdateStatus([FromBody] FieldForUpdatedExportRequestTurnRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;

            success = await exportRequestTurnService.UpdateStatus(itemModel.Id, itemModel.Status, itemModel.isPaymentWallet);
            if (success)
                appDomainResult.ResultCode = (int)HttpStatusCode.OK;
            else
                throw new Exception("Lỗi trong quá trình xử lý");
            appDomainResult.Success = success;

            return appDomainResult;
        }

        /// <summary>
        /// Cập nhật ghi chú
        /// </summary>
        /// <param name="id"></param>
        /// <param name="staffNote"></param>
        /// <returns></returns>
        [HttpPut("update-note")]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public async Task<AppDomainResult> UpdateNote(int id, string staffNote)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;

            var item = await this.domainService.GetByIdAsync(id);
            if (item == null)
                throw new KeyNotFoundException("Item không tồn tại");

            item.StaffNote = staffNote;

            var exItem = new System.Linq.Expressions.Expression<Func<ExportRequestTurn, object>>[]
            {
                e => e.StaffNote
            };

            success = await this.domainService.UpdateFieldAsync(item, exItem);
            if (success)
                appDomainResult.ResultCode = (int)HttpStatusCode.OK;
            else
                throw new Exception("Lỗi trong quá trình xử lý");
            appDomainResult.Success = success;

            return appDomainResult;
        }

        /// <summary>
        /// Xuất kho
        /// </summary>
        /// <param name="itemModel"></param>
        /// <returns></returns>
        [HttpPut("export")]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public async Task<AppDomainResult> Export(FieldForExportRequestTurnRequest itemModel)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = await exportRequestTurnService.Export(itemModel.Id, itemModel.SmallPackageIds, itemModel.IsRequest);
            if (success)
            {
                appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                appDomainResult.Success = success;
            }
            else
                throw new Exception("Lỗi trong quá trình xử lý");

            return appDomainResult;
        }
    }
}
