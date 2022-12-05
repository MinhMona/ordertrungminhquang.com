using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models
{
    public class MainOrderCodeModel : AppDomainModel
    {
        public int? MainOrderID { get; set; }

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Danh sách mã vận đơn
        /// </summary>
        [NotMapped]
        public List<string> OrderTransactionCode { get; set; } = new List<string>();
    }
}
