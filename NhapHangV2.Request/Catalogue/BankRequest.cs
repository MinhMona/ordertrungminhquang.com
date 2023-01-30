using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request.Catalogue
{
    public class BankRequest : AppDomainCatalogueRequest
    {
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string? BankNumber { get; set; }

        /// <summary>
        /// Chi nhánh
        /// </summary>
        public string? Branch { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string? IMG { get; set; }

        /// <summary>
        /// Hình ảnh mã QR
        /// </summary>
        public string? IMGQR { get; set; }
    }
}
