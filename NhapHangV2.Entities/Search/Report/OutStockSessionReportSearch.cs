using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search.Report
{
    public class OutStockSessionReportSearch : BaseSearch
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public int MainOrderId { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Từ ngày
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// Đến ngày
        /// </summary>
        public DateTime? ToDate { get; set; }
    }
}
