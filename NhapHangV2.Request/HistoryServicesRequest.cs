using NhapHangV2.Request.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Request
{
    public class HistoryServicesRequest : AppDomainRequest
    {
        public int? PostId { get; set; }

        public int? UID { get; set; }

        public int? OldStatus { get; set; }

        public string OldeStatusText { get; set; }

        public int? NewStatus { get; set; }

        public string NewStatusText { get; set; }

        public int? Type { get; set; }

        public string Note { get; set; }
    }
}
