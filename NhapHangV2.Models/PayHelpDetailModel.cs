using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class PayHelpDetailModel : AppDomainModel
    {
        public int? PayHelpId { get; set; }

        /// <summary>
        /// Giá tiền
        /// </summary>
        public decimal? Desc1 { get; set; }

        /// <summary>
        /// Nội dung
        /// </summary>
        public string Desc2 { get; set; }
    }
}
