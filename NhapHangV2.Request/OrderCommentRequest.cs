using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class OrderCommentRequest : AppDomainRequest
    {
        /// <summary>
        /// Id đơn hàng
        /// </summary>
        public int? MainOrderId { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 1. Nhắn tin với khách
        /// 2. Nhắn tin nội bộ
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// Lưu tập tin
        /// </summary>
        public string? FileLink { get; set; }
    }
}
