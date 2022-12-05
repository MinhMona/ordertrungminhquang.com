
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities
{
    public class HistoryServices : DomainEntities.AppDomain
    {
        public int? PostId { get; set; } = 0;

        public int? UID { get; set; } = 0;

        [NotMapped]
        public string UserName { get; set; } = string.Empty;

        public int? OldStatus { get; set; } = 0;

        [StringLength(1000)]
        public string OldeStatusText { get; set; } = string.Empty;

        public int? NewStatus { get; set; } = 0;

        [StringLength(1000)]
        public string NewStatusText { get; set; } = string.Empty;

        public int? Type { get; set; } = 0;

        [StringLength(1000)]
        public string Note { get; set; } = string.Empty;
    }
}
