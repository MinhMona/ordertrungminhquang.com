﻿using NhapHangV2.Entities;
using NhapHangV2.Extensions;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.Services.Auth;
using NhapHangV2.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using NhapHangV2.Models;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using NhapHangV2.Request;
using NhapHangV2.Entities.Search;
using NhapHangV2.Entities.Auth;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Entities.DomainEntities;

namespace NhapHangV2.API.Controllers
{
    [Route("api/fee-packaged")]
    [ApiController]
    [Description("Quản lý cấu hình phí đóng gỗ")]
    [Authorize]
    public class FeePackagedController : BaseController<FeePackaged, FeePackagedModel, FeePackagedRequest, BaseSearch>
    {
        public FeePackagedController(IServiceProvider serviceProvider, ILogger<BaseController<FeePackaged, FeePackagedModel, FeePackagedRequest, BaseSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.domainService = serviceProvider.GetRequiredService<IFeePackagedService>();
        }
    }
}
