using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request.Catalogue
{
    public class ServiceRequest : AppDomainCatalogueRequest
    {
        /// <summary>
        /// Link
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string? IMG { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public int? Position { get; set; }
    }
}
