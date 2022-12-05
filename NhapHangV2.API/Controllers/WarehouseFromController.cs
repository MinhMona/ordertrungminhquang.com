using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Models.Catalogue;
using NhapHangV2.Request.Catalogue;
using System.ComponentModel;
using System;
using NhapHangV2.Extensions;
using NhapHangV2.Utilities;
using System.Threading.Tasks;
using System.Text;
using NhapHangV2.Entities;
using System.Net;
using System.Text.RegularExpressions;

namespace NhapHangV2.API.Controllers
{
    [Route("api/warehousefrom")]
    [ApiController]
    [Description("Danh sách các kho TQ")]
    [Authorize]
    public class WarehouseFromController : BaseController<WarehouseFrom, WarehouseFromModel, WarehouseFromRequest, CatalogueSearch>
    {
        public WarehouseFromController(IServiceProvider serviceProvider, ILogger<BaseController<WarehouseFrom, WarehouseFromModel, WarehouseFromRequest, CatalogueSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.domainService = this.serviceProvider.GetRequiredService<IWarehouseFromService>();
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override async Task<AppDomainResult> AddItem([FromBody] WarehouseFromRequest request)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());

            Regex trimmer = new Regex(@"\s\s+");
            request.Name = trimmer.Replace(request.Name.Trim(), " ");
            request.Description = trimmer.Replace(ConvertToUnSign.convertToUnSign(request.Name).Trim(), " ");
            string code = request.Description.ToUpper().Trim();
            request.Code = code.Replace(" ", "-");

            var warehouseFrom = mapper.Map<WarehouseFrom>(request);
            if ((await this.domainService.GetExistItemMessage(warehouseFrom)) != string.Empty)
                throw new AppException("Kho đã tồn tại");
            success = await this.domainService.CreateAsync(warehouseFrom);
            if (success)
            {
                appDomainResult.ResultCode = (int)HttpStatusCode.OK;
                appDomainResult.Data = request;
            }
            else
                throw new Exception("Lỗi trong quá trình xử lý");
            appDomainResult.Success = success;
            return appDomainResult;
        }


    }


}
