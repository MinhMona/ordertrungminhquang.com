using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class FeeCheckProduct : DomainEntities.AppDomain
    {
        /// <summary>
        /// Số lượng từ
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? AmountFrom { get; set; } = 0;

        /// <summary>
        /// Số lượng đến
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? AmountTo { get; set; } = 0;

        /// <summary>
        /// Phí
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Fee { get; set; } = 0;

        /// <summary>
        /// Loại
        /// </summary>
        public int? Type { get; set; } = 0;

        /// <summary>
        /// Tên loại
        /// </summary>
        public string TypeName { get; set; }
    }
}
