using NhapHangV2.Models.Auth;
using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models
{
    public class FeePackagedModel : AppDomainModel
    {
        /// <summary>
        /// Số ký ban đầu
        /// </summary>
        public decimal? InitialKg { get; set; }

        /// <summary>
        /// Số tiền ký ban đầu
        /// </summary>
        public decimal? FirstPrice { get; set; }

        /// <summary>
        /// Số tiền cộng thêm trên mỗi ký
        /// </summary>
        public decimal? NextPrice { get; set; }
    }
}
