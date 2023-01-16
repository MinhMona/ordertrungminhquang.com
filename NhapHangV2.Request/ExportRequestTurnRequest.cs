using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class ExportRequestTurnRequest : AppDomainRequest
    {
        /// <summary>
        /// Tổng tiền (VNĐ)
        /// </summary>
        public decimal? TotalPriceVND { get; set; }

        /// <summary>
        /// Tổng tiền (tệ)
        /// </summary>
        public decimal? TotalPriceCNY { get; set; }

        /// <summary>
        /// Tổng kg
        /// </summary>
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// Ghi chú của nhân viên
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// ID đơn vị vận chuyển
        /// </summary>
        public int? ShippingTypeInVNId { get; set; }

        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Ghi chú của khách hàng
        /// </summary>
        public string? StaffNote { get; set; }

        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Trạng thái xuất kho
        /// </summary>
        public int? StatusExport { get; set; }

        /// <summary>
        /// Ngày xuất kho
        /// </summary>
        public DateTime? OutStockDate { get; set; }

        public int? Type { get; set; }

        public List<int>? SmallPackageIds { get; set; }
    }
}
