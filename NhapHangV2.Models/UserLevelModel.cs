using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class UserLevelModel : AppDomainModel
    {
        /// <summary>
        /// Cấp người dùng
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Chiết khấu phí mua hàng (%)	
        /// </summary>
        public decimal? FeeBuyPro { get; set; }

        /// <summary>
        /// Chiết khấu phí vận chuyển TQ - VN (%)
        /// </summary>
        public decimal? FeeWeight { get; set; }

        /// <summary>
        /// Đặt cọc tối thiểu (%)
        /// </summary>
        public decimal? LessDeposit { get; set; }

        /// <summary>
        /// Tiền từ (VNĐ)
        /// </summary>
        public decimal? Money { get; set; }

        /// <summary>
        /// Tiền đến (VNĐ)
        /// </summary>
        public decimal? MoneyTo { get; set; }
    }
}
