using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class VolumeFeeModel : AppDomainModel
    {
        /// <summary>
        /// ID từ kho
        /// </summary>
        public int? WarehouseFromId { get; set; }

        /// <summary>
        /// Tên từ kho
        /// </summary>
        public string WareHouseFromName { get; set; }

        /// <summary>
        /// ID đến kho
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        /// Tên đến kho
        /// </summary>
        public string WareHouseToName { get; set; }

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
        /// Id hình thức vận chuyển
        /// </summary>
        public int? ShippingTypeToWareHouseId { get; set; }

        /// <summary>
        /// Tên hình thức vận chuyển
        /// </summary>
        public string ShippingTypeToWareHouseName { get; set; }

        /// <summary>
        /// Loại đơn hàng (True: Đơn ký gửi, False: Đơn mua hộ)
        /// </summary>
        public bool? IsHelpMoving { get; set; }

        /// <summary>
        /// Tên loại đơn hàng
        /// </summary>
        public string HelpMovingName
        {
            get
            {
                switch (IsHelpMoving)
                {
                    case true:
                        return "Đơn ký gửi";
                    case false:
                        return "Đơn mua hộ";
                    default:
                        return string.Empty;
                }
            }
        }

    }
}
