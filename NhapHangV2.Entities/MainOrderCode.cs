
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class MainOrderCode : DomainEntities.AppDomain
    {
        public int? MainOrderID { get; set; } = 0;

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        [StringLength(100)]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Danh sách mã vận đơn
        /// </summary>
        [NotMapped]
        public List<string> OrderTransactionCode { get; set; } = new List<string>();
    }
}
