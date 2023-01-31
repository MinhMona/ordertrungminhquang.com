using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class TransportationOrderReport : AppDomainReport
    {
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Mã vận đơn
        /// </summary>
        public string OrderTransactionCode { get; set; } = string.Empty;

        /// <summary>
        /// Cân nặng
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Weight { get; set; } = 0;

        /// <summary>
        /// Kho TQ
        /// </summary>
        public string WareHouseFrom { get; set; } = string.Empty;

        /// <summary>
        /// Kho VN
        /// </summary>
        public string WareHouseTo { get; set; } = string.Empty;

        /// <summary>
        /// Phương thức vận chuyển
        /// </summary>
        public string ShippingTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Cước vật tư (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? SensorFeeVND { get; set; } = 0;

        /// <summary>
        /// Phụ phí hàng đặc biệt (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? AdditionFeeVND { get; set; } = 0;

        /// <summary>
        /// Tiền cân / Kg
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? FeeWeightPerKg { get; set; } = 0;

        /// <summary>
        /// Tổng tiền (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? TotalPriceVND { get; set; } = 0;

        /// <summary>
        /// Ngày về TQ
        /// </summary>
        public DateTime? DateInTQWarehouse { get; set; }

        /// <summary>
        /// Ngày về VN
        /// </summary>
        public DateTime? DateInLasteWareHouse { get; set; }
 
        /// <summary>
        /// Ngày về YKXK
        /// </summary>
        public DateTime? DateExportRequest { get; set; }

        /// <summary>
        /// Ngày XK
        /// </summary>
        public DateTime? DateExport { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// Tổng cân nặng
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal MaxWeight { get; set; } = 0;

        /// <summary>
        /// Tổng tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal MaxTotalPriceVND { get; set; } = 0;
    }
}
