using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class WarehouseFeeSearch : BaseSearch
    {
        /// <summary>
        /// Id kho TQ
        /// </summary>
        public int? WarehouseFromId { get; set; }

        /// <summary>
        /// Id kho VN
        /// </summary>
        public int? WarehouseId { get; set; }

        /// <summary>
        /// Id phương thức vận chuyển
        /// </summary>
        public int? ShippingTypeToWareHouseId { get; set; }

        /// <summary>
        /// Là đơn ký gửi
        /// </summary>
        public bool? IsHelpMoving { get; set; }
    }
}
