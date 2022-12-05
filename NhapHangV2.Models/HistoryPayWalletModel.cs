using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models
{
    public class HistoryPayWalletModel : AppDomainModel
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

        /// <summary>
        /// Tên loại giao dịch
        /// </summary>
        public string TradeTypeName 
        { 
            get
            {
                switch (TradeType)
                {
                    case (int)HistoryPayWalletContents.DatCoc:
                        return "Đặt cọc";
                    case (int)HistoryPayWalletContents.NhanLaiTienDatCoc:
                        return "Nhận lại tiền cọc";
                    case (int)HistoryPayWalletContents.ThanhToanHoaDon:
                        return "Thanh toán hóa đơn";
                    case (int)HistoryPayWalletContents.AdminChuyenTien:
                        return "Admin chuyển tiền";
                    case (int)HistoryPayWalletContents.RutTien:
                        return "Rút tiền";
                    case (int)HistoryPayWalletContents.HuyLenhRutTien:
                        return "Hủy lệnh rút tiền";
                    case (int)HistoryPayWalletContents.HoanTienKhieuNai:
                        return "Hoàn tiền khiếu nại";
                    case (int)HistoryPayWalletContents.ThanhToanVanChuyenHo:
                        return "Thanh toán vận chuyển hộ";
                    case (int)HistoryPayWalletContents.ThanhToanHo:
                        return "Thanh toán hộ";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Tổng tiền đã nạp (User)
        /// </summary>
        public decimal TotalAmount4 { get; set; }

        /// <summary>
        /// Số dư hiện tại (User)
        /// </summary>
        public decimal Wallet { get; set; }
    }
}
