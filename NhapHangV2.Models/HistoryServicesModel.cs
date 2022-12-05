using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models
{
    public class HistoryServicesModel : AppDomainModel
    {
        public int? PostId { get; set; }

        public int? UID { get; set; }

        public string UserName { get; set; }

        public int? OldStatus { get; set; }

        public string OldeStatusText { get; set; }

        public int? NewStatus { get; set; }

        public string NewStatusText { get; set; }

        public int? Type { get; set; }

        public string TypeName
        {
            get
            {
                switch (Type)
                {
                    case (int)TypeHistoryServices.VanChuyen:
                        return "Vận chuyển";
                    case (int)TypeHistoryServices.ThanhToanHo:
                        return "Thanh toán hộ";
                    default:
                        return string.Empty;
                }
            }
        }

        public string Note { get; set; }
    }
}
