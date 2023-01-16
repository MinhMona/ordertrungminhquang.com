using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class StaffIncomeRequest : AppDomainRequest
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public int? MainOrderId { get; set; }
        /// <summary>
        /// Mã đơn hàng ký gửi
        /// </summary>
        public int? TransportationOrderId { get; set; }
        /// <summary>
        /// Mã đơn hàng thanh toán hộ
        /// </summary>
        public int? PayHelpOrderId { get; set; }

        public decimal? OrderTotalPrice { get; set; }

        /// <summary>
        /// Phần trăm
        /// </summary>
        public decimal? PercentReceive { get; set; }

        /// <summary>
        /// ID người dùng
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Hoa hồng (VNĐ)
        /// </summary>
        public decimal? TotalPriceReceive { get; set; }

        public DateTime? OrderCreatedDate { get; set; }
    }
}
