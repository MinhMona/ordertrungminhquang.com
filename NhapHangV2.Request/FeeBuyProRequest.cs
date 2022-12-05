using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class FeeBuyProRequest : AppDomainRequest
    {
        /// <summary>
        /// Giá từ
        /// </summary>
        public decimal? PriceFrom { get; set; }

        /// <summary>
        /// Giá đến
        /// </summary>
        public decimal? PriceTo { get; set; }

        /// <summary>
        /// Phần trăm
        /// </summary>
        public decimal? FeePercent { get; set; }

        ///// <summary>
        ///// Phí theo tiền
        ///// </summary>
        //public decimal? FeeMoney { get; set; }
    }
}
