using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class RequestOutStockModel : AppDomainModel
    {
        public int? ExportRequestTurnId { get; set; }

        public int? SmallPackageId { get; set; }

        public int? Status { get; set; }

        public string StatusName 
        { 
            get {
                switch (Status)
                {
                    case 1:
                        return "Chờ xuất";
                    case 2:
                        return "Đã xuất";
                    default:
                        return string.Empty;
                }
            } 
        }

        public SmallPackageModel SmallPackage { get; set; }
    }
}
