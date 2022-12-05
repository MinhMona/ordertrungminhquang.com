
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class AccountantOutStockPayment : DomainEntities.AppDomain
    {
        public int? OutStockSessionID { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        public decimal? TotalPrice { get; set; } = 0;

        public int? UID { get; set; } = 0;

        [StringLength(200)]
        public string Note { get; set; } = string.Empty;
    }
}