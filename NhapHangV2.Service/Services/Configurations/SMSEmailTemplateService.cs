using NhapHangV2.Entities;
using NhapHangV2.Entities.Configuration;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.Configuration;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using NhapHangV2.Utilities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace NhapHangV2.Service.Services.Configurations
{
    public class SMSEmailTemplateService : CatalogueService<SMSEmailTemplates, CatalogueSearch>, ISMSEmailTemplateService
    {
        public SMSEmailTemplateService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
