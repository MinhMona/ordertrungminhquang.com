using NhapHangV2.Entities.Configuration;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface;
using NhapHangV2.Interface.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Interface.Services.Configuration;

namespace NhapHangV2.Service.Services.Configurations
{
    public class OTPHistoryService : DomainService<OTPHistories, BaseSearch>, IOTPHistoryService
    {
        public OTPHistoryService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
