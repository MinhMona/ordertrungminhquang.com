using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class WarehouseFeeRequest : AppDomainRequest
    {
        /// <summary>
        /// ID từ kho
        /// </summary>
        public int? WarehouseFromId { get; set; }

        /// <summary>
        /// ID đến kho
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        /// Cân nặng từ
        /// </summary>
        public decimal? WeightFrom { get; set; }

        /// <summary>
        /// Cân nặng đến
        /// </summary>
        public decimal? WeightTo { get; set; }

        /// <summary>
        /// Giá
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// ID hình thức vận chuyển
        /// </summary>
        public int? ShippingTypeToWareHouseId { get; set; }

        /// <summary>
        /// Loại đơn hàng (True: Đơn ký gửi, False: Đơn mua hộ)
        /// </summary>
        public bool? IsHelpMoving { get; set; }
    }
}
