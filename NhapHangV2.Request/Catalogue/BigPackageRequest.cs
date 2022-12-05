using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request.Catalogue
{
    public class BigPackageRequest : AppDomainCatalogueRequest
    {
        /// <summary>
        /// Cân nặng (kg)
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Khối (m3)
        /// </summary>
        public decimal? Volume { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; } = 1;

        public List<SmallPackageRequest>? SmallPackages { get; set; }
    }
}
