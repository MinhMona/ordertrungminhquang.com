using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class UpdateFieldOrderShopTempRequest
    {
        public int? Id { get; set; }

        /// <summary>
        /// Giao tận nhà
        /// </summary>
        public bool? IsFastDelivery { get; set; } = false;

        /// <summary>
        /// Kiểm hàng
        /// </summary>
        public bool? IsCheckProduct { get; set; } = false;

        /// <summary>
        /// Đóng gỗ
        /// </summary>
        public bool? IsPacked { get; set; } = false;

        /// <summary>
        /// Bảo hiểm
        /// </summary>
        public bool? IsInsurance { get; set; } = false;
    }
}
