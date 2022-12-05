
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class PayAllOrderHistory : DomainEntities.AppDomain
    {
        public int? MainOrderId { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")] 
        public decimal? Amount { get; set; } = 0;

        public int? UID { get; set; } = 0;

        public string Note { get; set; } = string.Empty;

        public int? Status { get; set; } = 0;
    }
}
