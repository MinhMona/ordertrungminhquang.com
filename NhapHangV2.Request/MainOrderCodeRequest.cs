using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class MainOrderCodeRequest : AppDomainRequest
    {
        public int? MainOrderID { get; set; }

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        [StringLength(100)]
        public string Code { get; set; }
    }
}
