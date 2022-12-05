using AutoMapper;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services.Catalogue
{
    public class WarehouseFromService : CatalogueService<WarehouseFrom, CatalogueSearch>, IWarehouseFromService
    {
        public WarehouseFromService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
