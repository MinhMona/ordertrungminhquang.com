using AutoMapper;
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
    public class HistoryPayWalletService : DomainService<HistoryPayWallet, HistoryPayWalletSearch>, IHistoryPayWalletService
    {
        public HistoryPayWalletService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        //public async Task<bool> CreateHistory(int type, int tradeType, int uID, int mainOrderID, int amount, int moneyLeft)
        //{
        //    HistoryPayWallet historyPayWallet = new HistoryPayWallet();
        //    historyPayWallet = new HistoryPayWallet();
        //}

        protected override string GetStoreProcName()
        {
            return "HistoryPayWallet_GetPagingData";
        }
    }
}
