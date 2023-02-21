using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.SQLEntities
{
    public class PriceInMonth
    {
        public decimal TotalPriceVND { get; set; }
        public decimal Deposit { get; set; }
        public decimal UnDeposit { get; set; }
    }
}
