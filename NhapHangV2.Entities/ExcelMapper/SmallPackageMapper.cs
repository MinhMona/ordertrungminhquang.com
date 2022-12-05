using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.ExcelMapper
{
    public class SmallPackageMapper
    {
        /// <summary>
        /// Mã vận đơn
        /// </summary>
        [Column(1)]
        public string OrderTransactionCode { get; set; }

        /// <summary>
        /// Cân nặng
        /// </summary>
        [Column(2)]
        public decimal Weight { get; set; }
    }
}
