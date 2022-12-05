
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class UserLevel : DomainEntities.AppDomain
    {
        /// <summary>
        /// Cấp người dùng
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Chiết khấu phí mua hàng (%)	
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? FeeBuyPro { get; set; } = 0;

        /// <summary>
        /// Chiết khấu phí vận chuyển TQ - VN (%)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? FeeWeight { get; set; } = 0;

        /// <summary>
        /// Đặt cọc tối thiểu (%)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? LessDeposit { get; set; } = 0;

        /// <summary>
        /// Tiền từ (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Money { get; set; } = 0;

        /// <summary>
        /// Tiền đến (VNĐ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? MoneyTo { get; set; } = 0;
    }
}
