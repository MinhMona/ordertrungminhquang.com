using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class ExportRequestTurnSearch : BaseSearch
    {
        public int? UID { get; set; }

        public int? Status { get; set; }

        public string UserName { get; set; }

        public string OrderTransactionCode { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
