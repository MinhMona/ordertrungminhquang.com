
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class HistoryPayWallet : DomainEntities.AppDomain
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// ID shop
        /// </summary>
        public int? MainOrderId { get; set; } = 0;

        /// <summary>
        /// Số tiền
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Amount { get; set; } = 0;

        /// <summary>
        /// Nội dung
        /// </summary>
        [StringLength(1000)]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Số dư
        /// </summary>
        [Column(TypeName = "decimal(18,0)")]
        public decimal? MoneyLeft { get; set; } = 0;

        /// <summary>
        /// 1: Trừ, 2: Cộng
        /// </summary>
        public int? Type { get; set; } = 0;

        /// <summary>
        /// Loại giao dịch
        /// </summary>
        public int? TradeType { get; set; } = 0;

        /// <summary>
        /// Tổng tiền đã nạp (User)
        /// </summary>
        [NotMapped]
        public decimal TotalAmount4 { get; set; } = 0;

        /// <summary>
        /// Số dư hiện tại (User)
        /// </summary>
        [NotMapped]
        public decimal Wallet { get; set; } = 0;
    }
}
