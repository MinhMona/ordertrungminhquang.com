using AutoMapper;
using NhapHangV2.Entities;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class OutStockSessionPackageService : DomainService<OutStockSessionPackage, BaseSearch>, IOutStockSessionPackageService
    {
        public OutStockSessionPackageService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "Admin_Get_OutStockSessionPackage";
        }
    }
}
