
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class FeePackaged : DomainEntities.AppDomain
    {
        /// <summary>
        /// Số ký ban đầu
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? InitialKg { get; set; } = 0;

        /// <summary>
        /// Số tiền ký ban đầu
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? FirstPrice { get; set; } = 0;

        /// <summary>
        /// Số tiền cộng thêm trên mỗi ký
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? NextPrice { get; set; } = 0;
    }
}
