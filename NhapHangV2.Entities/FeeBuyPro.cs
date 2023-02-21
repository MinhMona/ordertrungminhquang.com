
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class FeeBuyPro : DomainEntities.AppDomain
    {
        /// <summary>
        /// Giá từ
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PriceFrom { get; set; } = 0;

        /// <summary>
        /// Giá đến
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? PriceTo { get; set; } = 0;

        /// <summary>
        /// Phí theo phần trăm
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? FeePercent { get; set; } = 0;
    }
}
