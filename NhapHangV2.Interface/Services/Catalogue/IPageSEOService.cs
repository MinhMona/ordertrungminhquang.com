﻿using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Interface.Services.Catalogue
{
    public interface IPageSEOService : ICatalogueService<PageSEO, CatalogueSearch>
    {
    }
}
