using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Request
{
    public class AdminSendUserWalletRequest : AppDomainRequest
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// ID ngân hàng
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; } = (int)WalletStatus.DangChoDuyet;

        /// <summary>
        /// Nội dung
        /// </summary>
        public string? TradeContent { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string? IMG { get; set; }
    }
}
