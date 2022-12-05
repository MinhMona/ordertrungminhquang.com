using AutoMapper;
using Microsoft.Data.SqlClient;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.DomainEntities;
using NhapHangV2.Interface.Services.Catalogue;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services.Catalogue
{
    public class BankService : CatalogueService<Bank, CatalogueSearch>, IBankService
    {
        public BankService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            IsUseStore = true;
        }

        protected override string GetStoreProcName()
        {
            return "Bank_GetPagingData";
        }
    }
}
