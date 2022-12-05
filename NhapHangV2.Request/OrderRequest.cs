using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class OrderRequest : AppDomainRequest
    {
        /// <summary>
        /// Tên sản phẩm (gốc)
        /// </summary>
        public string? TitleOrigin { get; set; }

        /// <summary>
        /// Số lượng
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int? Quantity { get; set; }

        /// <summary>
        /// Giá sản phẩm 
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PriceOrigin { get; set; } //=PricePromotion

        /// <summary>
        /// Giá mua thực tế (tệ)
        /// </summary>
        public decimal? RealPrice { get; set; }

        /// <summary>
        /// Ghi chú sản phẩm
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// Trạng thái (1: Còn hàng, 2: Hết hàng)
        /// </summary>
        public int? ProductStatus { get; set; }
    }
}
