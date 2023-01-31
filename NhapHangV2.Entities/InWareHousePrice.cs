
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class InWareHousePrice : DomainEntities.AppDomain
    {
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
        /// Tổng ngày
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? MaxDay { get; set; } = 0;

        /// <summary>
        /// Giá tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? PricePay { get; set; } = 0;
    }
}
