using NhapHangV2.Entities.DomainEntities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NhapHangV2.Models.Auth;
using NhapHangV2.Interface.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using NhapHangV2.BaseAPI.Controllers;
using NhapHangV2.Request.Auth;
using NhapHangV2.Entities.Auth;

namespace NhapHangV2.API.Controllers.Auth
{
    [Route("api/permission")]
    [ApiController]
    [Description("Quyền người dùng")]
    [Authorize]
    public class PermissionController : BaseCatalogueController<Permissions, PermissionModel, PermissionRequest, CatalogueSearch>
    {
        protected PermissionController(IServiceProvider serviceProvider, ILogger<BaseController<Permissions, PermissionModel, PermissionRequest, CatalogueSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.catalogueService = serviceProvider.GetRequiredService<IPermissionService>();
        }
    }
}
