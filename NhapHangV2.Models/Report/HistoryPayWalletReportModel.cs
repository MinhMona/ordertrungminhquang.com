using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Report
{
    public class HistoryPayWalletReportModel : AppDomainReportModel
    {
        /// <summary>
        /// Nội dung
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Loại giao dịch
        /// </summary>
        public int TradeType { get; set; }

        /// <summary>
        /// Số dư
        /// </summary>
        public decimal MoneyLeft { get; set; }

        /// <summary>
        /// Tổng số tiền giao dịch
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Tổng tiền đặt cọc
        /// </summary>
        public decimal TotalDeposit { get; set; }

        /// <summary>
        /// Tổng tiền nhận lại đặt cọc
        /// </summary>
        public decimal TotalReciveDeposit { get; set; }

        /// <summary>
        /// Tổng tiền thanh toán hóa đơn
        /// </summary>
        public decimal TotalPaymentBill { get; set; }

        /// <summary>
        /// Tổng tiền admin nạp tiền
        /// </summary>
        public decimal TotalAdminSend { get; set; }

        /// <summary>
        /// Tổng rút tiền
        /// </summary>
        public decimal TotalWithDraw { get; set; }

        /// <summary>
        /// Tổng hủy rút tiền
        /// </summary>
        public decimal TotalCancelWithDraw { get; set; }

        /// <summary>
        /// Tổng nhận tiền khiếu nại
        /// </summary>
        public decimal TotalComplain { get; set; }

        /// <summary>
        /// Tổng tiền thanh toán vận chuyển hộ
        /// </summary>
        public decimal TotalPaymentTransport { get; set; }

        /// <summary>
        /// Tổng tiền thanh toán hộ
        /// </summary>
        public decimal TotalPaymentHo { get; set; }

        /// <summary>
        /// Tổng tiền thanh toán lưu kho
        /// </summary>
        public decimal TotalPaymentSaveWare { get; set; }

        /// <summary>
        /// Tổng tiền nhận lại vận chuyển hộ
        /// </summary>
        public decimal TotalRecivePaymentTransport { get; set; }
    }
}
