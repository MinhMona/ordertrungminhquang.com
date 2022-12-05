using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class YCGModel : AppDomainModel
    {
        //public int? UID { get; set; }

        public int? MainOrderId { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Note { get; set; }

        //public int? Status { get; set; }
    }
}
