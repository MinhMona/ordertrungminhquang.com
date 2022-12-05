using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models
{
    public class HistoryPayWalletCNYModel : AppDomainModel
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Số tiền
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// Số dư
        /// </summary>
        public decimal? MoneyLeft { get; set; }

        /// <summary>
        /// 1: trừ, 2: cộng
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Loại giao dịch
        /// </summary>
        public int? TradeType { get; set; }

        /// <summary>
        /// Tên loại giao dịch
        /// </summary>
        public string TradeTypeName
        {
            get
            {
                switch (TradeType)
                {
                    case (int)HistoryPayWalletCNYContents.ThanhToanVanChuyenHo:
                        return "Thanh toán đơn hàng vận chuyển hộ";
                    case (int)HistoryPayWalletCNYContents.RutTien:
                        return "Rút tiền";
                    case (int)HistoryPayWalletCNYContents.NapTien:
                        return "Nạp tiền";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Note { get; set; }
    }
}
