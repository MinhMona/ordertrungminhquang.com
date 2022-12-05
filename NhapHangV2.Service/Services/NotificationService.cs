using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Auth;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Service.Services
{
    public class NotificationService : DomainService<Notification, NoticationSearch>, INotificationService
    {
        public NotificationService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "Notification_GetPagingData";
        }
    }
}
