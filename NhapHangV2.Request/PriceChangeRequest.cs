using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class PriceChangeRequest : AppDomainRequest
    {
        /// <summary>
        /// Giá tệ từ
        /// </summary>
        public decimal? PriceFromCNY { get; set; }

        /// <summary>
        /// Giá tệ đến
        /// </summary>
        public decimal? PriceToCNY { get; set; }

        /// <summary>
        /// Tiền VNĐ
        /// </summary>
        public decimal? PriceVND { get; set; }

        /// <summary>
        /// VIP 0
        /// </summary>
        public decimal? Vip0 { get; set; }

        /// <summary>
        /// VIP 1
        /// </summary>
        public decimal? Vip1 { get; set; }

        /// <summary>
        /// VIP 2
        /// </summary>
        public decimal? Vip2 { get; set; }

        /// <summary>
        /// VIP 3
        /// </summary>
        public decimal? Vip3 { get; set; }

        /// <summary>
        /// VIP 4
        /// </summary>
        public decimal? Vip4 { get; set; }

        /// <summary>
        /// VIP 5
        /// </summary>
        public decimal? Vip5 { get; set; }

        /// <summary>
        /// VIP 6
        /// </summary>
        public decimal? Vip6 { get; set; }

        /// <summary>
        /// VIP 7
        /// </summary>
        public decimal? Vip7 { get; set; }

        /// <summary>
        /// VIP 8
        /// </summary>
        public decimal? Vip8 { get; set; }
    }
}
