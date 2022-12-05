using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class ToolConfigRequest : AppDomainRequest
    {
        /// <summary>
        /// Site: 1: Taobao, 2: Tmall, 3: 1688
        /// </summary>
        public int Site { get; set; }
        /// <summary>
        /// Nội dung thay đổi
        /// </summary>
        public string? Content { get; set; }
    }
}
