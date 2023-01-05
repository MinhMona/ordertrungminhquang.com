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
    [Route("api/shippingtypetowarehouse")]
    [ApiController]
    [Description("Danh sách phương thức vận chuyển TQ-VN")]
    [Authorize]
    public class ShippingTypeToWareHouseController : BaseController<ShippingTypeToWareHouse, ShippingTypeToWareHouseModel, ShippingTypeToWareHouseRequest, CatalogueSearch>
    {
        public ShippingTypeToWareHouseController(IServiceProvider serviceProvider, ILogger<ControllerBase> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            domainService = this.serviceProvider.GetRequiredService<IShippingTypeToWareHouseService>();
        }

        /// <summary>
        /// Thêm mới item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [AppAuthorize(new int[] { CoreContants.AddNew })]
        public override async Task<AppDomainResult> AddItem([FromBody] ShippingTypeToWareHouseRequest request)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            Regex trimmer = new Regex(@"\s\s+");
            request.Name = trimmer.Replace(request.Name, " ");
            request.Description = trimmer.Replace(ConvertToUnSign.convertToUnSign(request.Name), " ");
            string code = request.Description.ToUpper().Trim();
            request.Code = code.Replace(" ", "-");
            var shippingTypeToWareHouse = mapper.Map<ShippingTypeToWareHouse>(request);
            if (await domainService.GetExistItemMessage(shippingTypeToWareHouse) != string.Empty)
                throw new Exception("Phương thức vận chuyển đã tồn tại");
            success = await domainService.CreateAsync(shippingTypeToWareHouse);
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
        /// Thêm mới item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [AppAuthorize(new int[] { CoreContants.Update })]
        public override async Task<AppDomainResult> UpdateItem([FromBody] ShippingTypeToWareHouseRequest request)
        {
            AppDomainResult appDomainResult = new AppDomainResult();
            bool success = false;
            if (!ModelState.IsValid)
                throw new AppException(ModelState.GetErrorMessage());
            Regex trimmer = new Regex(@"\s\s+");
            request.Name = trimmer.Replace(request.Name, " ");
            request.Description = trimmer.Replace(ConvertToUnSign.convertToUnSign(request.Name), " ");
            string code = request.Description.ToUpper().Trim();
            request.Code = code.Replace(" ", "-");
            var shippingTypeToWareHouse = mapper.Map<ShippingTypeToWareHouse>(request);
            if (await domainService.GetExistItemMessage(shippingTypeToWareHouse) != string.Empty)
                throw new Exception("Phương thức vận chuyển đã tồn tại");
            success = await domainService.UpdateAsync(shippingTypeToWareHouse);
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
