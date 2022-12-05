using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class PayHelpReport : AppDomainReport
    {
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Tổng tiền (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal TotalPrice { get; set; } = 0;

        /// <summary>
        /// Tiền gốc (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal TotalPriceVNDGiaGoc { get; set; } = 0;

        /// <summary>
        /// Tiền thu (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal TotalPriceVND { get; set; } = 0;

        /// <summary>
        /// Tiền lời (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal Profit { get; set; } = 0;

        /// <summary>
        /// Tổng tiền tệ
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxTotalPrice { get; set; } = 0;

        /// <summary>
        /// Tổng tiền vốn
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxTotalPriceVND { get; set; } = 0;

        /// <summary>
        /// Tổng tiền thu
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxTotalPriceVNDGiaGoc { get; set; } = 0;

        /// <summary>
        /// Tổng tiền lời
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxProfit { get; set; } = 0;
    }
}
