using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Report
{
    public class MainOrderRealReportModel : AppDomainReportModel
    {
        /// <summary>
        /// Tổng tiền mua hàng thật (tệ)
        /// </summary>
        public decimal? MaxTotalPriceRealCNY { get; set; }
    }
}
