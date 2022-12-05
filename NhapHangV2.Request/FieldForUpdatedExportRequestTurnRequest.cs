using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class FieldForUpdatedExportRequestTurnRequest
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public bool isPaymentWallet { get; set; } = true;
    }
}
