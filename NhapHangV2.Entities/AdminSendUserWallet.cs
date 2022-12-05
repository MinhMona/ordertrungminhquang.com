
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
    public class AdminSendUserWallet : DomainEntities.AppDomain
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// ID Bank
        /// </summary>
        public int? BankId { get; set; } = 0;

        /// <summary>
        /// Số tiền
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
        [StringLength(100)]
        public string TradeContent { get; set; } = string.Empty;

        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string IMG { get; set; } = string.Empty;

        /// <summary>
        /// UserName
        /// </summary>
        [NotMapped]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Số đơn chờ duyệt
        /// </summary>
        [NotMapped]
        public int? TotalStatus1 { get; set; } = 0;

        /// <summary>
        /// Số đơn đã duyệt
        /// </summary>
        [NotMapped]
        public int? TotalStatus2 { get; set; } = 0;

        /// <summary>
        /// Số đơn đã hủy
        /// </summary>
        [NotMapped]
        public int? TotalStatus3 { get; set; } = 0;

        /// <summary>
        /// Số dư (User)
        /// </summary>
        [NotMapped]
        public decimal? Wallet { get; set; } = 0;

        /// <summary>
        /// Tổng số tiền
        /// </summary>
        [NotMapped]
        public decimal? TotalAmount { get; set; } = 0;

        /// <summary>
        /// Tổng số tiền đã duyệt
        /// </summary>
        [NotMapped]
        public decimal? TotalAmount2 { get; set; } = 0;

        /// <summary>
        /// Tổng số tiền chờ duyệt
        /// </summary>
        [NotMapped]
        public decimal? TotalAmount1 { get; set; } = 0;

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [NotMapped]
        public string BankName { get; set; } = string.Empty;
    }
}