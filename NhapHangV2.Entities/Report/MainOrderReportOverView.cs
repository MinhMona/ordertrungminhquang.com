using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class MainOrderReportOverView
    {
        public string Name { get; set; }

        public decimal? Total { get; set; }
        public decimal? NotPay { get; set; }

        public decimal? Pay { get; set; }


    }
}
