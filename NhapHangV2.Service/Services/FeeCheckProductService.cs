using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class FeeCheckProductService : DomainService<FeeCheckProduct, BaseSearch>, IFeeCheckProductService
    {
        public FeeCheckProductService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        protected override string GetStoreProcName()
        {
            return "FeeCheckProduct_GetPagingData";
        }

        public async Task<FeeCheckProduct> GetFeeCheckByPriceAndAmount(decimal price, decimal amount)
        {
            int type = 1;
            if(price < 10)
                type = 2;
            return await Queryable.Where(x => x.Type == type && (amount >= x.AmountFrom.Value && amount <= x.AmountTo.Value)).FirstOrDefaultAsync();
        }
    }
}
