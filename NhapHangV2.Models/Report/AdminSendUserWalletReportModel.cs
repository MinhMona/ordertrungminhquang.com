using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models.Report
{
    public class AdminSendUserWalletReportModel : AppDomainReportModel
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Tổng số tiền
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Tên trạng thái
        /// </summary>
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case (int)WalletStatus.DangChoDuyet:
                        return "Đang chờ duyệt";
                    case (int)WalletStatus.DaDuyet:
                        return "Đã duyệt";
                    case (int)WalletStatus.Huy:
                        return "Hủy";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Ngân hàng
        /// </summary>
        public string BankName { get; set; }
    }
}
