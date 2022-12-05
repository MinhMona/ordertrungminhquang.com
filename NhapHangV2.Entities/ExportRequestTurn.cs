
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Entities
{
    public class ExportRequestTurn : DomainEntities.AppDomain
    {
        /// <summary>
        /// Tổng tiền (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? TotalPriceVND { get; set; } = 0;

        /// <summary>
        /// Tổng tiền (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? TotalPriceCNY { get; set; } = 0;

        /// <summary>
        /// Tổng kg
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? TotalWeight { get; set; } = 0;

        /// <summary>
        /// Ghi chú của nhân viên
        /// </summary>
        [StringLength(1000)]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// ID hình thức vận chuyển
        /// </summary>
        public int? ShippingTypeInVNId { get; set; } = 0;

        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// Ghi chú của khách hàng
        /// </summary>
        [StringLength(1000)]
        public string StaffNote { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        public int? Status { get; set; } = (int)ExportRequestTurnStatus.ChuaThanhToan;

        /// <summary>
        /// Trạng thái xuất kho
        /// </summary>
        public int? StatusExport { get; set; } = (int)ExportRequestTurnStatusExport.ChuaXuatKho;

        /// <summary>
        /// Ngày xuất kho
        /// </summary>
        public DateTime? OutStockDate { get; set; }

        /// <summary>
        /// Tổng số kiện
        /// </summary>
        public int? TotalPackage { get; set; } = 0;

        public int? Type { get; set; } = 0;

        /// <summary>
        /// UserName
        /// </summary>
        [NotMapped]
        public string UserName { get; set; } = string.Empty;

        [NotMapped]
        public string BarCodeAndDateOut { get; set; } = string.Empty;

        [NotMapped]
        public List<TransportationOrder> TransportationOrders { get; set; } = new List<TransportationOrder>();

        [NotMapped]
        public List<SmallPackage> SmallPackages { get; set; } = new List<SmallPackage>();

        [NotMapped]
        public List<int> SmallPackageIds { get; set; } = new List<int>();
    }
}
