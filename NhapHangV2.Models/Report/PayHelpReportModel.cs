using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Report
{
    public class PayHelpReportModel : AppDomainReportModel
    {
        public string UserName { get; set; }

        /// <summary>
        /// Tổng tiền (tệ)
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Tiền gốc (VNĐ)
        /// </summary>
        public decimal TotalPriceVNDGiaGoc { get; set; }

        /// <summary>
        /// Tiền thu (VNĐ)
        /// </summary>
        public decimal TotalPriceVND { get; set; }

        /// <summary>
        /// Tiền lời (VNĐ)
        /// </summary>
        public decimal Profit { get; set; }

        /// <summary>
        /// Tổng tiền tệ
        /// </summary>
        public decimal MaxTotalPrice { get; set; }

        /// <summary>
        /// Tổng tiền vốn
        /// </summary>
        public decimal MaxTotalPriceVND { get; set; }

        /// <summary>
        /// Tổng tiền thu
        /// </summary>
        public decimal MaxTotalPriceVNDGiaGoc { get; set; }

        /// <summary>
        /// Tổng tiền lời
        /// </summary>
        public decimal MaxProfit { get; set; }
    }
}
