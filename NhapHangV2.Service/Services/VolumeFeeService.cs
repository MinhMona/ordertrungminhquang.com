using AutoMapper;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class VolumeFeeService : DomainService<VolumeFee, VolumeFeeSearch>, IVolumeFeeService
    {
        public VolumeFeeService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "VolumeFee_GetPagingData";
        }
        protected override string GetStoreProcNameGetById()
        {
            return "VolumeFee_GetById";
        }
    }
}
