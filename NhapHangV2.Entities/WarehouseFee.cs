
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class WarehouseFee : DomainEntities.AppDomain
    {
        /// <summary>
        /// ID từ kho
        /// </summary>
        public int? WarehouseFromId { get; set; } = 0;

        /// <summary>
        /// Tên từ kho
        /// </summary>
        [NotMapped]
        public string WarehouseFromName { get; set; } = string.Empty;

        /// <summary>
        /// ID đến kho
        /// </summary>
        public int? WarehouseId { get; set; } = 0;

        /// <summary>
        /// Tên đến kho
        /// </summary>
        [NotMapped]
        public string WareHouseToName { get; set; } = string.Empty;

        /// <summary>
        /// Cân nặng từ
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? WeightFrom { get; set; } = 0;

        /// <summary>
        /// Cân nặng đến
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? WeightTo { get; set; } = 0;

        /// <summary>
        /// Giá
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Price { get; set; } = 0;

        /// <summary>
        /// ID Hình thức vận chuyển
        /// </summary>
        public int? ShippingTypeToWareHouseId { get; set; } = 0;

        /// <summary>
        /// Tên hình thức vận chuyển
        /// </summary>
        [NotMapped]
        public string ShippingTypeToWareHouseName { get; set; } = string.Empty;

        /// <summary>
        /// Loại đơn hàng (True: Đơn ký gửi, False: Đơn mua hộ)
        /// </summary>
        public bool? IsHelpMoving { get; set; } = false;
    }
}
