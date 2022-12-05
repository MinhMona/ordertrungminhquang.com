﻿using AutoMapper;
using Microsoft.Data.SqlClient;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Search;
using NhapHangV2.Interface.Services;
using NhapHangV2.Interface.UnitOfWork;
using NhapHangV2.Service.Services.DomainServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Service.Services
{
    public class HistoryPayWalletCNYService : DomainService<HistoryPayWalletCNY, HistoryPayWalletCNYSearch>, IHistoryPayWalletCNYService
    {
        public HistoryPayWalletCNYService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        protected override string GetStoreProcName()
        {
            return "HistoryPayWalletCNY_GetPagingData";
        }
    }
}
