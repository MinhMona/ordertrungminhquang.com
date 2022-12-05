using NhapHangV2.Entities;
using NhapHangV2.Entities.Configuration;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Interface.Services.Configuration
{
    public interface ISMSEmailTemplateService : ICatalogueService<SMSEmailTemplates, CatalogueSearch>
    {
    }
}
