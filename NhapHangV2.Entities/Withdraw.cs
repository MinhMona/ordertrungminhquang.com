
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Entities
{
    public class Withdraw : DomainEntities.AppDomain
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// UserName
        /// </summary>
        [NotMapped]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Họ tên khách
        /// </summary>
        [NotMapped]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Số tiền nạp
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Amount { get; set; } = 0;

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; } = (int)WalletStatus.DangChoDuyet;

        /// <summary>
        /// Nội dung
        /// </summary>
        [StringLength(1000)]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Loại
        /// </summary>
        public int? Type { get; set; } = 0;

        /// <summary>
        /// Ngân hàng
        /// </summary>
        [StringLength(100)]
        public string BankAddress { get; set; } = string.Empty;

        /// <summary>
        /// Số tài khoản
        /// </summary>
        [StringLength(50)]
        public string BankNumber { get; set; } = string.Empty;

        /// <summary>
        /// Người hưởng
        /// </summary>
        [StringLength(50)]
        public string Beneficiary { get; set; } = string.Empty;

        /// <summary>
        /// Số đơn 
        /// </summary>
        [NotMapped]
        public int? TotalStatus { get; set; }
        /// <summary>
        /// Số đơn chờ duyệt
        /// </summary>
        [NotMapped]
        public int? TotalStatus1 { get; set; }

        /// <summary>
        /// Số đơn đã duyệt
        /// </summary>
        [NotMapped]
        public int? TotalStatus2 { get; set; }

        /// <summary>
        /// Số đơn đã hủy
        /// </summary>
        [NotMapped]
        public int? TotalStatus3 { get; set; }

        /// <summary>
        /// Tổng số tiền
        /// </summary>
        [NotMapped]
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Tổng số tiền đã duyệt
        /// </summary>
        [NotMapped]
        public decimal? TotalAmount2 { get; set; }

        /// <summary>
        /// Tổng số tiền chờ duyệt
        /// </summary>
        [NotMapped]
        public decimal? TotalAmount1 { get; set; }
    }
}
