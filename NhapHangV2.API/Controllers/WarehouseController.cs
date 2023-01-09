using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Models.Catalogue;
using NhapHangV2.Request.Catalogue;
using NhapHangV2.Utilities;
using System;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers
{
    [Route("api/warehouse")]
    [ApiController]
    [Description("Danh sách các kho VN")]
    [Authorize]
    public class WarehouseController : BaseController<Warehouse, WarehouseModel, WarehouseRequest, CatalogueSearch>
    {
        public WarehouseController(IServiceProvider serviceProvider, ILogger<BaseController<Warehouse, WarehouseModel, WarehouseRequest, CatalogueSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            domainService = this.serviceProvider.GetRequiredService<IWarehouseService>();
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override async Task<AppDomainResult> AddItem([FromBody] WarehouseRequest request)
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

            var warehouse = mapper.Map<Warehouse>(request);
            if ((await this.domainService.GetExistItemMessage(warehouse)) != string.Empty)
                throw new AppException("Kho đã tồn tại");
            success = await this.domainService.CreateAsync(warehouse);
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
        /// <summary>
        /// Cập nhật item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public override async Task<AppDomainResult> UpdateItem([FromBody] WarehouseRequest request)
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
            var warehouse = mapper.Map<Warehouse>(request);
            if ((await this.domainService.GetExistItemMessage(warehouse)) != string.Empty)
                throw new AppException("Kho đã tồn tại");
            success = await this.domainService.UpdateAsync(warehouse);
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
