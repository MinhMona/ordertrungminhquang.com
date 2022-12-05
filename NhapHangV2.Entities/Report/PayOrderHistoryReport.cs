using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class PayOrderHistoryReport : AppDomainReport
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public int MainOrderId { get; set; } = 0;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Loại thanh toán
        /// </summary>
        public int Status { get; set; } = 0;
        
        /// <summary>
        /// Số tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal Amount { get; set; } = 0;
    }
}
