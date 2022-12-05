using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Models.Report
{
    public class OutStockSessionReportModel : AppDomainReportModel
    {
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public int? MainOrderId { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Tổng tiền
        /// </summary>
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Tên trạng thái
        /// </summary>
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case 1:
                        return "Chưa xử lý";
                    case 2:
                        return "Đã xử lý";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
