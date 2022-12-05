using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class WithdrawRequest : AppDomainRequest
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Số tiền nạp
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Loại (2: Rút tiền, 3: Nạp tiền)
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Ngân hàng
        /// </summary>
        public string? BankAddress { get; set; }

        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string? BankNumber { get; set; }

        /// <summary>
        /// Người hưởng
        /// </summary>
        public string? Beneficiary { get; set; }
    }
}
