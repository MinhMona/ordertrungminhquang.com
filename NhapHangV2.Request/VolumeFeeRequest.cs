using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class VolumeFeeRequest : AppDomainRequest
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
        /// Thể tích từ
        /// </summary>
        public decimal? VolumeFrom { get; set; }

        /// <summary>
        /// Thể tích đến
        /// </summary>
        public decimal? VolumeTo { get; set; }

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
