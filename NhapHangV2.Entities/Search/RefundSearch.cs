using NhapHangV2.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Entities.Search
{
    public class RefundSearch : BaseSearch
    {
        /// <summary>
        /// Trạng thái
        /// </summary>
        public int? Status { get; set; }
    }
}
