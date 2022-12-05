using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class HistoryPayWalletRequest : AppDomainRequest
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Id Shop
        /// </summary>
        public int? MainOrderId { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Số dư
        /// </summary>
        public decimal? MoneyLeft { get; set; }

        /// <summary>
        /// 1 là trừ, 2 là cộng
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Loại giao dịch
        /// </summary>
        public int? TradeType { get; set; }
    }
}
