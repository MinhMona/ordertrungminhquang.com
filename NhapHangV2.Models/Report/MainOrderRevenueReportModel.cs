using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Report
{
    public class MainOrderRevenueReportModel : AppDomainReportModel
    {
        public string UserName { get; set; }

        /// <summary>
        /// Giá trị đơn hàng
        /// </summary>
        public decimal TotalPriceVND { get; set; }

        /// <summary>
        /// Tiền hàng
        /// </summary>
        public decimal PriceVND { get; set; }

        /// <summary>
        /// Phí mua hàng
        /// </summary>
        public decimal FeeBuyPro { get; set; }

        /// <summary>
        /// Vận chuyển nội địa
        /// </summary>
        public decimal FeeShipCN { get; set; }

        /// <summary>
        /// Cân nặng
        /// </summary>
        public decimal TQVNWeight { get; set; }

        /// <summary>
        /// Vận chuyển TQ - VN
        /// </summary>
        public decimal FeeWeight { get; set; }

        /// <summary>
        /// Phí đơn hàng
        /// </summary>
        public decimal OrderFee { get; set; }

        /// <summary>
        /// Mặc cả
        /// </summary>
        public decimal BargainMoney { get; set; }

        /// <summary>
        /// Số đơn hàng
        /// </summary>
        public int TotalOrder { get; set; }

        /// <summary>
        /// Số khách hàng
        /// </summary>
        public int TotalCus { get; set; }

        /// <summary>
        /// Tổng giá trị đơn hàng
        /// </summary>
        public decimal MaxTotalPriceVND { get; set; }

        /// <summary>
        /// Tổng tiền hàng
        /// </summary>
        public decimal MaxPriceVND { get; set; }

        /// <summary>
        /// Tổng phí mua hàng
        /// </summary>
        public decimal MaxFeeBuyPro { get; set; }

        /// <summary>
        /// Tổng vận chuyển nội địa
        /// </summary>
        public decimal MaxFeeShipCN { get; set; }

        /// <summary>
        /// Tổng cân nặng
        /// </summary>
        public decimal MaxTQVNWeight { get; set; }

        /// <summary>
        /// Tổng vận chuyển TQ
        /// </summary>
        public decimal MaxFeeWeight { get; set; }

        /// <summary>
        /// Tổng phí đơn hàng
        /// </summary>
        public decimal MaxOrderFee { get; set; }

        /// <summary>
        /// Tổng mặc cả
        /// </summary>
        public decimal MaxBargainMoney { get; set; }

        /// <summary>
        /// Tổng số đơn hàng
        /// </summary>
        public int MaxTotalOrder { get; set; }
    }
}
