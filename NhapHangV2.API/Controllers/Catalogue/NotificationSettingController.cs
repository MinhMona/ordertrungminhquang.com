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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NhapHangV2.API.Controllers.Catalogue
{
    [Route("api/notification-setting")]
    [ApiController]
    [Description("Cấu hình thông báo")]
    [Authorize]
    public class NotificationSettingController : BaseCatalogueController<NotificationSetting, NotificationSettingModel, NotificationSettingRequest, CatalogueSearch>
    {
        public NotificationSettingController(IServiceProvider serviceProvider, ILogger<BaseCatalogueController<NotificationSetting, NotificationSettingModel, NotificationSettingRequest, CatalogueSearch>> logger, IWebHostEnvironment env) : base(serviceProvider, logger, env)
        {
            this.catalogueService = serviceProvider.GetRequiredService<INotificationSettingService>();
        }
    }
}
