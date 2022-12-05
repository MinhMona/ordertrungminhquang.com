using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class MainOrderRealReport : AppDomainReport
    {
        /// <summary>
        /// Tổng tiền mua hàng thật (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxTotalPriceRealCNY { get; set; } = 0;
    }
}
