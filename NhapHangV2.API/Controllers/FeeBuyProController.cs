using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services;
using NhapHangV2.Models;
using NhapHangV2.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers
{
    [Route("api/fee-buy-pro")]
    [ApiController]
    [Description("Cấu hình phí dịch vụ mua hàng")]
    [Authorize]
    public class FeeBuyProController : BaseController<FeeBuyPro, FeeBuyProModel, FeeBuyProRequest, BaseSearch>
    {
        public FeeBuyProController(IServiceProvider serviceProvider, ILogger<BaseController<FeeBuyPro, FeeBuyProModel, FeeBuyProRequest, BaseSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.domainService = this.serviceProvider.GetRequiredService<IFeeBuyProService>();
        }
    }
}
