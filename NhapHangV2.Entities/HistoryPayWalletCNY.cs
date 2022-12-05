
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class HistoryPayWalletCNY: DomainEntities.AppDomain
    {
        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; } = 0;

        /// <summary>
        /// Số tiền
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
        public decimal? Amount { get; set; } = 0;

        /// <summary>
        /// Số dư
        /// </summary>
        [Column(TypeName = "decimal(18,2)")] 
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
        /// Nội dung
        /// </summary>
        [StringLength(1000)]
        public string Note { get; set; } = string.Empty;
    }
}
