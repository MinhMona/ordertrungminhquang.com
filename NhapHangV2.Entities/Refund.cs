
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
    public class Refund : DomainEntities.AppDomain
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
        /// Số tiền (tệ)
        /// </summary>
        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Amount { get; set; } = 0;

        /// <summary>
        /// Nội dung
        /// </summary>
        [StringLength(1000)]
        public string Note { get; set; } = string.Empty;

        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; } = (int)WalletStatus.DangChoDuyet;
    }
}
