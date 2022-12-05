using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NhapHangV2.Request.DomainRequests
{
    public class AppDomainRequest
    {
        public int Id { get; set; } = 0;

        /// <summary>
        /// Cờ check xóa
        /// </summary>
        public bool Deleted { get; set; } = false;

        /// <summary>
        /// Cờ active
        /// </summary>
        public bool Active { get; set; } = true;
    }
}
