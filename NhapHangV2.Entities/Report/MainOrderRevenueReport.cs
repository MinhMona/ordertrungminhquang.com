using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class MainOrderRevenueReport : AppDomainReport
    {
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Giá trị đơn hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal TotalPriceVND { get; set; } = 0;

        /// <summary>
        /// Tiền hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal PriceVND { get; set; } = 0;

        /// <summary>
        /// Phí mua hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal FeeBuyPro { get; set; } = 0;

        /// <summary>
        /// Vận chuyển nội địa
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal FeeShipCN { get; set; } = 0;

        /// <summary>
        /// Cân nặng
        /// </summary>
        [Column(TypeName = "decimal(18,1)")] 
        public decimal TQVNWeight { get; set; } = 0;

        /// <summary>
        /// Vận chuyển TQ - VN
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal FeeWeight { get; set; } = 0;

        /// <summary>
        /// Phí đơn hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal OrderFee { get; set; } = 0;

        /// <summary>
        /// Mặc cả
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal BargainMoney { get; set; } = 0;

        /// <summary>
        /// Số đơn hàng
        /// </summary>
        public int TotalOrder { get; set; } = 0;

        /// <summary>
        /// Số khách hàng
        /// </summary>
        public int TotalCus { get; set; } = 0;

        /// <summary>
        /// Tổng giá trị đơn hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxTotalPriceVND { get; set; } = 0;

        /// <summary>
        /// Tổng tiền hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxPriceVND { get; set; } = 0;

        /// <summary>
        /// Tổng phí mua hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxFeeBuyPro { get; set; } = 0;

        /// <summary>
        /// Tổng vận chuyển nội địa
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxFeeShipCN { get; set; } = 0;

        /// <summary>
        /// Tổng cân nặng
        /// </summary>
        [Column(TypeName = "decimal(18,1)")] 
        public decimal MaxTQVNWeight { get; set; } = 0;

        /// <summary>
        /// Tổng vận chuyển TQ
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxFeeWeight { get; set; } = 0;

        /// <summary>
        /// Tổng phí đơn hàng
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxOrderFee { get; set; } = 0;

        /// <summary>
        /// Tổng mặc cả
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxBargainMoney { get; set; } = 0;

        /// <summary>
        /// Tổng số đơn hàng
        /// </summary>
        public int MaxTotalOrder { get; set; } = 0;
    }
}
