using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Entities;
using NhapHangV2.Models;
using NhapHangV2.Request;
using System.ComponentModel;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NhapHangV2.Interface.Services;
using NhapHangV2.Entities.Search;

namespace NhapHangV2.API.Controllers
{
    [Route("api/tool-config")]
    [ApiController]
    [Description("Cấu hình công cụ")]
    [Authorize]
    public class ToolConfigController : BaseController<ToolConfig, ToolConfigModel, ToolConfigRequest, ToolConfigSearch>
    {
        public ToolConfigController(IServiceProvider serviceProvider,
            ILogger<BaseController<ToolConfig, ToolConfigModel, ToolConfigRequest, ToolConfigSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.domainService = this.serviceProvider.GetRequiredService<IToolConfigService>();
        }
    }
}
