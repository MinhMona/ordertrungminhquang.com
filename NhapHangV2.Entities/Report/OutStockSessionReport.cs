using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class OutStockSessionReport : AppDomainReport
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public int UID { get; set; } = 0;

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public int MainOrderId { get; set; } = 0;

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Tổng tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal TotalPrice { get; set; } = 0;

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; } = 0;
    }
}
