using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Report
{
    public class AdminSendUserWalletReport : AppDomainReport
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Số tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Amount { get; set; } = 0;

        /// <summary>
        /// Tổng số tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? TotalAmount { get; set; } = 0;

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; } = 0;

        /// <summary>
        /// Ngân hàng
        /// </summary>
        public string BankName { get; set; } = string.Empty;
    }
}
