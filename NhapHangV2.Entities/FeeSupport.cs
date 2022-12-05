
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class FeeSupport : DomainEntities.AppDomain
    {
        public int? MainOrderId { get; set; } = 0;

        /// <summary>
        /// Tên phụ phí
        /// </summary>
        [StringLength(100)]
        public string SupportName { get; set; } = string.Empty;

        /// <summary>
        /// Số tiền (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? SupportInfoVND { get; set; } = 0;
    }
}
